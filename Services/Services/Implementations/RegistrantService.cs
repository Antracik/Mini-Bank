using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Data;
using Data.Entities;
using Services.Models;
using Services.Services;

namespace Services.Services.Implementations
{
    public class RegistrantService : IRegistrantService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly IDateService _dateService;

        public RegistrantService(IMapper mapper, UnitOfWork unitOfWork, IDateService dateService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _dateService = dateService;
        }

        public int CreateRegistrant(RegistrantServiceModel registrant)
        {

            _unitOfWork.AddRepository<RegistrantEntityModel>();

            var registrantEntity = _mapper.Map<RegistrantEntityModel>(registrant);

            _dateService.SetDateCreatedNow(ref registrantEntity);

            _unitOfWork.GetRepository<RegistrantEntityModel>().AddItem(registrantEntity);
            _unitOfWork.Save();

            return registrantEntity.Id;
        }

        public int DeleteRegistrant(int id)
        {
            int userId;

            _unitOfWork.AddRepository<RegistrantEntityModel>();

            var registrantRepo = _unitOfWork.GetRepository<RegistrantEntityModel>();

            var registrantEntity = registrantRepo.Get(reg => reg.Id == id, null, "Wallets").FirstOrDefault();

            if (registrantEntity.Wallets.Any())
            {
                return -1;
            }

            userId = registrantEntity.UserId;

            registrantRepo.Delete(id);

            _unitOfWork.Save();

            return userId;
        }

        public IEnumerable<RegistrantServiceModel> GetAllRegistrants()
        {
            _unitOfWork.AddRepository<RegistrantEntityModel>();
           
            var registrantEntities = _unitOfWork.GetRepository<RegistrantEntityModel>().Get(null, null, "CountryRelation").ToList();

            var registrantModels = _mapper.Map<List<RegistrantServiceModel>>(registrantEntities);

            return registrantModels;
        }

        public IEnumerable<RegistrantServiceModel> GetAllRegistrants(string orderBy, string filterBy)
        {
            var repo = _unitOfWork.AddRepository<RegistrantEntityModel>().GetRepository<RegistrantEntityModel>();

            var registrantEntities = new List<RegistrantEntityModel>();

            switch(orderBy)
            {
                case "Id":
                    registrantEntities = repo.Get(null, x => x.OrderBy(y => y.Id), "CountryRelation").ToList();
                    break;
                case "Id_desc":
                    registrantEntities = repo.Get(null, x => x.OrderByDescending(y => y.Id), "CountryRelation").ToList();
                    break;
                case "FirstName":
                    registrantEntities = repo.Get(null, x => x.OrderBy(y => y.FirstName), "CountryRelation").ToList();
                    break;
                case "FirstName_desc":
                    registrantEntities = repo.Get(null, x => x.OrderByDescending(y => y.FirstName), "CountryRelation").ToList();
                    break;
                case "LastName":
                    registrantEntities = repo.Get(null, x => x.OrderBy(y => y.LastName), "CountryRelation").ToList();
                    break;
                case "LastName_desc":
                    registrantEntities = repo.Get(null, x => x.OrderByDescending(y => y.LastName), "CountryRelation").ToList();
                    break;
                case "Country":
                    registrantEntities = repo.Get(null, x => x.OrderBy(y => y.CountryRelation.Name), "CountryRelation").ToList();
                    break;
                case "Country_desc":
                    registrantEntities = repo.Get(null, x => x.OrderByDescending(y => y.CountryRelation.Name), "CountryRelation").ToList();
                    break;
                case "Address":
                    registrantEntities = repo.Get(null, x => x.OrderBy(y => y.Address), "CountryRelation").ToList();
                    break;
                case "Address_desc":
                    registrantEntities = repo.Get(null, x => x.OrderByDescending(y => y.Address), "CountryRelation").ToList();
                    break;
                default:
                    registrantEntities = repo.Get(null, x => x.OrderBy(y => y.Id), "CountryRelation").ToList();
                    break;
            }

            var registrantModels = _mapper.Map<List<RegistrantServiceModel>>(registrantEntities);

            return registrantModels;
        }

        public RegistrantServiceModel GetRegistrantByUserId(int userId, bool includeWallets = false)
        {
            var registrantEntity = new RegistrantEntityModel();

            _unitOfWork.AddRepository<RegistrantEntityModel>().AddRepository<WalletEntityModel>();

            if (includeWallets)
            {
                registrantEntity = _unitOfWork.GetRepository<RegistrantEntityModel>().Get(reg => reg.UserId == userId, null, "CountryRelation").FirstOrDefault();
                if (registrantEntity != null)
                {
                    var wallets = _unitOfWork.GetRepository<WalletEntityModel>().Get(wallet => wallet.RegistrantId == registrantEntity.Id, null, "Status").ToList();
                    registrantEntity.Wallets = wallets;
                }
            }
            else
            {
                registrantEntity = _unitOfWork.GetRepository<RegistrantEntityModel>().Get(reg => reg.UserId == userId, null, "CountryRelation").FirstOrDefault();
            }

            var registrantModels = _mapper.Map<RegistrantServiceModel>(registrantEntity);

            return registrantModels;
        }

        public RegistrantServiceModel GetRegistrantById(int id, bool includeWallets = false)
        {
            var registrantEntity = new RegistrantEntityModel();

            _unitOfWork.AddRepository<RegistrantEntityModel>().AddRepository<WalletEntityModel>();
            
            if (includeWallets)
            {
                registrantEntity = _unitOfWork.GetRepository<RegistrantEntityModel>().Get(reg => reg.Id == id, null, "CountryRelation").FirstOrDefault();
                var wallets = _unitOfWork.GetRepository<WalletEntityModel>().Get(wallet => wallet.RegistrantId == registrantEntity.Id, null, "Status").ToList();
                registrantEntity.Wallets = wallets;
            }
            else
            {
                registrantEntity = _unitOfWork.GetRepository<RegistrantEntityModel>().Get(reg => reg.Id == id, null, "CountryRelation").FirstOrDefault();
            }

            var registrantModels = _mapper.Map<RegistrantServiceModel>(registrantEntity);

            return registrantModels;
        }

        public void UpdateRegistrant(RegistrantServiceModel registrant)
        {
            _unitOfWork.AddRepository<RegistrantEntityModel>();
            
            var registrantEntity = _mapper.Map<RegistrantEntityModel>(registrant);

            _dateService.SetDateEditedNow(ref registrantEntity);

            _unitOfWork.GetRepository<RegistrantEntityModel>().Update(registrantEntity);
            _unitOfWork.Save();
        }
    }
}
