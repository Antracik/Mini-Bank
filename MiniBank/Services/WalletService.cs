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
    public class WalletService : IWalletService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public WalletService(IMapper mapper, UnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public int CreateWallet(WalletModel wallet)
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

        public IEnumerable<WalletDbRepoModel> GetAllWallets()
        {
            var walletEntities = new List<WalletDbRepoModel>();

            _unitOfWork.Add<WalletDbRepoModel>();
            
            walletEntities = _unitOfWork.GetRepository<WalletDbRepoModel>().Get(null, null, "Status").ToList();
            
            return walletEntities;
        }

        public WalletDbRepoModel GetWalletById(int id, bool includeAccounts = false)
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

            return walletEntity;
        }

        public void UpdateWallet(WalletModel wallet)
        {
            _unitOfWork.Add<WalletDbRepoModel>();
            
            var walletEntity = _mapper.Map<WalletDbRepoModel>(wallet);

            _unitOfWork.GetRepository<WalletDbRepoModel>().Update(walletEntity);
            _unitOfWork.Save();
        }
    }
}
