using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Data;
using Data.Entities;
using Data.Queries;
using Services.Models;
using Services.Services;

namespace Services.Services
{
    public class WalletService : IWalletService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly IDateService _dateService;

        public WalletService(IMapper mapper, UnitOfWork unitOfWork, IDateService dateService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _dateService = dateService;
        }

        public int CreateWallet(WalletServiceModel wallet)
        {
            _unitOfWork.Add<WalletDbRepoModel>();
            
            var walletEntity = _mapper.Map<WalletDbRepoModel>(wallet);

            walletEntity.RegistrantId = wallet.RegistrantId;

            _dateService.SetDateCreatedNow(ref walletEntity);

            _unitOfWork.GetRepository<WalletDbRepoModel>().AddItem(walletEntity);
            _unitOfWork.Save();
            
            return walletEntity.Id;
        }

        public int DeleteRegistrant(int id)
        {
            int registrantId;

            _unitOfWork.Add<WalletDbRepoModel>();
            var walletRepo = _unitOfWork.GetRepository<WalletDbRepoModel>();

            var walletEntity = walletRepo.Get(reg => reg.Id == id, null, "Accounts").FirstOrDefault();

            if (walletEntity.Accounts.Any())
            {
                return -1;
            }

            registrantId = walletEntity.RegistrantId;

            walletRepo.Delete(id);

            _unitOfWork.Save();

            return registrantId;
        }

        public IEnumerable<WalletServiceModel> GetAllWallets()
        {
            _unitOfWork.Add<WalletDbRepoModel>();
            
            var walletEntities = _unitOfWork.GetRepository<WalletDbRepoModel>().Get(null, null, "Status").ToList();

            var walletModels = _mapper.Map<List<WalletServiceModel>>(walletEntities);

            return walletModels;
        }

        public IEnumerable<WalletServiceModel> GetAllWallets(string orderBy, string filter)
        {
            var repo = _unitOfWork.Add<WalletDbRepoModel>().GetRepository<WalletDbRepoModel>();

            var walletEntities = new List<WalletDbRepoModel>();

            switch(orderBy)
            {
                case "Id":
                    walletEntities = repo.Get(null, x => x.OrderBy(y => y.Id), "Status").ToList();
                    break;
                case "Id_desc":
                    walletEntities = repo.Get(null, x => x.OrderByDescending(y => y.Id), "Status").ToList();
                    break;
                case "Number":
                    walletEntities = repo.Get(null, x => x.OrderBy(y => y.Number), "Status").ToList();
                    break;
                case "Number_desc":
                    walletEntities = repo.Get(null, x => x.OrderByDescending(y => y.Number), "Status").ToList();
                    break;
                case "WalletStatus":
                    walletEntities = repo.Get(null, x => x.OrderBy(y => y.Status), "Status").ToList();
                    break;
                case "WalletStatus_desc":
                    walletEntities = repo.Get(null, x => x.OrderByDescending(y => y.Status), "Status").ToList();
                    break;
                case "Verified":
                    walletEntities = repo.Get(null, x => x.OrderBy(y => y.IsVerified), "Status").ToList();
                    break;
                case "Verified_desc":
                    walletEntities = repo.Get(null, x => x.OrderByDescending(y => y.IsVerified), "Status").ToList();
                    break;
                default:
                    walletEntities = repo.Get(null, x => x.OrderBy(y => y.Id), "Status").ToList();
                    break;
            }

            var walletModels = _mapper.Map<List<WalletServiceModel>>(walletEntities);

            return walletModels;
        }

        public WalletServiceModel GetWalletById(int id, bool includeAccounts = false)
        {
            var walletEntity = new WalletDbRepoModel();

            _unitOfWork.Add<WalletDbRepoModel>().Add<AccountDbRepoModel>();
            
            if (includeAccounts)
            {
                walletEntity = _unitOfWork.GetRepository<WalletDbRepoModel>().Get(wallet => wallet.Id == id, null, "Status").FirstOrDefault();
                var accounts = _unitOfWork.GetRepository<AccountDbRepoModel>().Get(account => account.WalletId == walletEntity.Id, null, "Status,CurrencyRelation").ToList();
                walletEntity.Accounts = accounts;
            }
            else
            {
                walletEntity = _unitOfWork.GetRepository<WalletDbRepoModel>().Get(wallet => wallet.Id == id, null, "Status").FirstOrDefault();
            }

            var walletModels = _mapper.Map<WalletServiceModel>(walletEntity);

            return walletModels;
        }

        public void UpdateWallet(WalletServiceModel wallet)
        {
            _unitOfWork.Add<WalletDbRepoModel>();
            
            var walletEntity = _mapper.Map<WalletDbRepoModel>(wallet);

            _dateService.SetDateEditedNow(ref walletEntity);

            _unitOfWork.GetRepository<WalletDbRepoModel>().Update(walletEntity);
            _unitOfWork.Save();
        }
    }
}
