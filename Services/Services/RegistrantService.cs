using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Data;
using Data.Entities;
using Services.Models;
using Services.Services;

namespace Services.Services
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

            _unitOfWork.Add<RegistrantDbRepoModel>();

            var registrantEntity = _mapper.Map<RegistrantDbRepoModel>(registrant);

            _dateService.SetDateCreatedNow(ref registrantEntity);

            _unitOfWork.GetRepository<RegistrantDbRepoModel>().AddItem(registrantEntity);
            _unitOfWork.Save();

            return registrantEntity.Id;
        }

        public int DeleteRegistrant(int id)
        {
            int userId;

            _unitOfWork.Add<RegistrantDbRepoModel>();

            var registrantRepo = _unitOfWork.GetRepository<RegistrantDbRepoModel>();

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
            _unitOfWork.Add<RegistrantDbRepoModel>();
           
            var registrantEntities = _unitOfWork.GetRepository<RegistrantDbRepoModel>().Get(null, null, "CountryRelation").ToList();

            var registrantModels = _mapper.Map<List<RegistrantServiceModel>>(registrantEntities);

            return registrantModels;
        }

        public RegistrantServiceModel GetRegistrantById(int id, bool includeWallets = false)
        {
            var registrantEntity = new RegistrantDbRepoModel();

            _unitOfWork.Add<RegistrantDbRepoModel>().Add<WalletDbRepoModel>();
            
            if (includeWallets)
            {
                registrantEntity = _unitOfWork.GetRepository<RegistrantDbRepoModel>().Get(reg => reg.Id == id, null, "CountryRelation").FirstOrDefault();
                var wallets = _unitOfWork.GetRepository<WalletDbRepoModel>().Get(wallet => wallet.RegistrantId == registrantEntity.Id, null, "Status").ToList();
                registrantEntity.Wallets = wallets;
            }
            else
            {
                registrantEntity = _unitOfWork.GetRepository<RegistrantDbRepoModel>().Get(reg => reg.Id == id, null, "CountryRelation").FirstOrDefault();
            }

            var registrantModels = _mapper.Map<RegistrantServiceModel>(registrantEntity);

            return registrantModels;
        }

        public void UpdateRegistrant(RegistrantServiceModel registrant)
        {
            _unitOfWork.Add<RegistrantDbRepoModel>();
            
            var registrantEntity = _mapper.Map<RegistrantDbRepoModel>(registrant);

            _dateService.SetDateEditedNow(ref registrantEntity);

            _unitOfWork.GetRepository<RegistrantDbRepoModel>().Update(registrantEntity);
            _unitOfWork.Save();
        }
    }
}
