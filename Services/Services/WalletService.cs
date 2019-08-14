using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Data;
using Data.Entities;

namespace Services.Models
{
    public class WalletService : IWalletService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public WalletService(IMapper mapper, UnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public int CreateWallet(WalletServiceModel wallet)
        {
            _unitOfWork.Add<WalletDbRepoModel>();
            
            var walletEntity = _mapper.Map<WalletDbRepoModel>(wallet);

            walletEntity.RegistrantId = wallet.RegistrantId;

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

            walletEntity.DateEdited = DateTime.Now;

            _unitOfWork.GetRepository<WalletDbRepoModel>().Update(walletEntity);
            _unitOfWork.Save();
        }
    }
}
