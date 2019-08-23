﻿using AutoMapper;
using Data;
using Data.Entities;
using Services.Models;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly IDateService _dateService;

        public AccountService(IMapper mapper, UnitOfWork unitOfWork, IDateService dateService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _dateService = dateService;
        }

        public int CreateAccount(AccountServiceModel account)
        {

            _unitOfWork.Add<AccountDbRepoModel>();

            var accountEntity = _mapper.Map<AccountDbRepoModel>(account);

            _dateService.SetDateCreatedNow(ref accountEntity);

            _unitOfWork.GetRepository<AccountDbRepoModel>().AddItem(accountEntity);
            _unitOfWork.Save();

            return accountEntity.Id;
        }

        public int DeleteAccount(int id)
        {
            int wallId;

            _unitOfWork.Add<AccountDbRepoModel>();

            var accountRepo = _unitOfWork.GetRepository<AccountDbRepoModel>();

            wallId = accountRepo.Get(acc => acc.Id == id).FirstOrDefault().WalletId;

            accountRepo.Delete(id);

            _unitOfWork.Save();
            
            return wallId;
        }

        public AccountServiceModel GetAccountById(int id)
        {
            _unitOfWork.Add<AccountDbRepoModel>();

            var accountEnity = _unitOfWork.GetRepository<AccountDbRepoModel>().Get(acc => acc.Id == id, null, "Status,CurrencyRelation").FirstOrDefault();

            var accountModel = _mapper.Map<AccountServiceModel>(accountEnity);

            return accountModel;
        }

        public IEnumerable<AccountServiceModel> GetAllAccounts()
        {
            _unitOfWork.Add<AccountDbRepoModel>();
            
            var accountEntities = _unitOfWork.GetRepository<AccountDbRepoModel>().Get(null, null, "Status,CurrencyRelation").ToList();

            var accountModels = _mapper.Map<List<AccountServiceModel>>(accountEntities);

            return accountModels;
        }

        public void UpdateAccount(AccountServiceModel account)
        {
            _unitOfWork.Add<AccountDbRepoModel>();
           
            var accountEntity = _mapper.Map<AccountDbRepoModel>(account);

            _dateService.SetDateEditedNow(ref accountEntity);

            _unitOfWork.GetRepository<AccountDbRepoModel>().Update(accountEntity);
            _unitOfWork.Save();
        }
    }
}
