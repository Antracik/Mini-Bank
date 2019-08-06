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
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public AccountService(IMapper mapper, UnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public int CreateAccount(AccountModel account)
        {
            var accountEntity = new AccountDbRepoModel();

            using (_unitOfWork.Add<AccountDbRepoModel>())
            {
                accountEntity = _mapper.Map<AccountDbRepoModel>(account);

                _unitOfWork.GetRepository<AccountDbRepoModel>().AddItem(accountEntity);
                _unitOfWork.Save();
            }

            return accountEntity.Id;
        }

        public int DeleteAccount(int id)
        {
            int wallId;

            using (_unitOfWork.Add<AccountDbRepoModel>())
            {
                var accountRepo = _unitOfWork.GetRepository<AccountDbRepoModel>();

                wallId = accountRepo.Get(acc => acc.Id == id).FirstOrDefault().WalletId;

                accountRepo.Delete(id);

                _unitOfWork.Save();
            }

            return wallId;
        }

        public AccountDbRepoModel GetAccountById(int id)
        {
            var accountEnity = new AccountDbRepoModel();

            using (_unitOfWork.Add<AccountDbRepoModel>())
            {
                accountEnity = _unitOfWork.GetRepository<AccountDbRepoModel>().Get(acc => acc.Id == id, null, "Status,CurrencyRelation").FirstOrDefault();
            }

            return accountEnity;
        }

        public IEnumerable<AccountDbRepoModel> GetAllAccounts()
        {
            var accountEntities = new List<AccountDbRepoModel>();

            using (_unitOfWork.Add<AccountDbRepoModel>())
            {
                accountEntities = _unitOfWork.GetRepository<AccountDbRepoModel>().Get(null, null, "Status,CurrencyRelation").ToList();
            }

            return accountEntities;
        }

        public void UpdateAccount(AccountModel account)
        {
            using (_unitOfWork.Add<AccountDbRepoModel>())
            {
                var accountEntity = _mapper.Map<AccountDbRepoModel>(account);

                _unitOfWork.GetRepository<AccountDbRepoModel>().Update(accountEntity);
                _unitOfWork.Save();
            }
        }
    }
}
