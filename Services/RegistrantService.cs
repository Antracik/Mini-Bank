using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mini_Bank.DbRepo;
using Mini_Bank.DbRepo.Entities;
using Mini_Bank.Models;

namespace Mini_Bank.Services
{
    public class RegistrantService : IRegistrantService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public RegistrantService(IMapper mapper, UnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public int CreateRegistrant(RegistrantModel registrant)
        {
            var registrantEntity = new RegistrantDbRepoModel();

            using (_unitOfWork.Add<RegistrantDbRepoModel>())
            {
                registrantEntity = _mapper.Map<RegistrantDbRepoModel>(registrant);

                _unitOfWork.GetRepository<RegistrantDbRepoModel>().AddItem(registrantEntity);
                _unitOfWork.Save();
            }

            return registrantEntity.Id;
        }

        public int DeleteRegistrant(int id)
        {
            int userId;

            using (_unitOfWork.Add<RegistrantDbRepoModel>())
            {
                var registrantRepo = _unitOfWork.GetRepository<RegistrantDbRepoModel>();

                var registrantEntity = registrantRepo.Get(reg => reg.Id == id, null, "Wallets").FirstOrDefault();

                if (registrantEntity.Wallets.Any())
                {
                    return -1;
                }

                userId = registrantEntity.UserId;

                registrantRepo.Delete(id);

                _unitOfWork.Save();
            }

            return userId;
        }

        public IEnumerable<RegistrantDbRepoModel> GetAllRegistrants()
        {
            var registrantEntities = new List<RegistrantDbRepoModel>();

            using (_unitOfWork.Add<RegistrantDbRepoModel>())
            {
                registrantEntities = _unitOfWork.GetRepository<RegistrantDbRepoModel>().Get(null, null, "CountryRelation").ToList();
            }

            return registrantEntities;
        }

        public RegistrantDbRepoModel GetRegistrantById(int id, bool includeWallets = false)
        {
            var registrantEntity = new RegistrantDbRepoModel();
            
            using (_unitOfWork.Add<RegistrantDbRepoModel>().Add<WalletDbRepoModel>())
            {
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
            }

            return registrantEntity;
        }

        public void UpdateRegistrant(RegistrantModel registrant)
        {
            using (_unitOfWork.Add<RegistrantDbRepoModel>())
            {
                var registrantEntity = _mapper.Map<RegistrantDbRepoModel>(registrant);

                _unitOfWork.GetRepository<RegistrantDbRepoModel>().Update(registrantEntity);

                _unitOfWork.Save();
            }
        }
    }
}
