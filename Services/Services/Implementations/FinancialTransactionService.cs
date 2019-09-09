﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Data;
using Data.Entities;
using Services.Models;
using Shared;

namespace Services.Services.Implementations
{
    public class FinancialTransactionService : IFinancialTransactionService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDateService _dateService;
        private readonly ICurrencyService _currencyService;
        private readonly INomenclatureService _nomenclatureService;

        public FinancialTransactionService(UnitOfWork unitOfWork,
                                            IMapper mapper,
                                            IDateService dateService,
                                            ICurrencyService currencyService,
                                            INomenclatureService nomenclatureService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dateService = dateService;
            _nomenclatureService = nomenclatureService;
            _currencyService = currencyService;
        }

        public int AddTransaction(FinancialTransactionServiceModel transaction)
        {
            var entity = _mapper.Map<TransactionEntityModel>(transaction);

            _dateService.SetDateCreatedNow(ref entity);

            _unitOfWork.Add<TransactionEntityModel>()
                       .GetRepository<TransactionEntityModel>()
                       .AddItem(entity);

            return entity.Id;
        }

        public int EnactTransaction(AccountServiceModel sender, decimal amount, int currentUserId, string toIBAN, AccountServiceModel recipient = null)
        {
            int senderTransactionId = int.MinValue;
            decimal unconvertedAmount = amount;
            string uniqueIdentifier = Guid.NewGuid().ToString(); 

            using (var dbTransaction = _unitOfWork.BankContext.Database.BeginTransaction())
            {
                try
                {
                    _unitOfWork.Add<AccountEntityModel>().Add<TransactionEntityModel>();

                    var accountRepo = _unitOfWork.GetRepository<AccountEntityModel>();
                    var transactionRepo = _unitOfWork.GetRepository<TransactionEntityModel>();

                    // deduct money from the senders account
                    sender.Balance -= amount;

                    if (recipient != null)
                    {
                        // give money to recipient
                        if (recipient.CurrencyId != sender.CurrencyId)
                        {
                            double rate = _currencyService.GetExchangeRate(sender.CurrencyId, recipient.CurrencyId);

                            // do we have the exchange rate
                            if (rate == double.MinValue)
                            {
                                // see if exchange rate exists backwards
                                rate = _currencyService.GetExchangeRate(recipient.CurrencyId, sender.CurrencyId);

                                amount /= decimal.Parse(rate.ToString());
                            }
                            else
                            {
                                amount *= decimal.Parse(rate.ToString());
                            }

                        }

                        recipient.Balance += amount;

                        var recipientEntity = _mapper.Map<AccountEntityModel>(recipient);

                        accountRepo.Update(recipientEntity);

                        var recipientTransactionEntity = new TransactionEntityModel
                        {
                            AccountId = recipientEntity.Id,
                            CurrencyId = sender.CurrencyId,
                            Amount = unconvertedAmount,
                            CreatedById = currentUserId,
                            UniqueTransactionIdentifier = uniqueIdentifier,
                            ToIBAN = null,
                            TransactionTypeId = (int)TransactionTypeEnum.TransactionType.Debit
                        };

                        _dateService.SetDateCreatedNow(ref recipientTransactionEntity);
                        transactionRepo.AddItem(recipientTransactionEntity);
                    }

                    var senderEntity = _mapper.Map<AccountEntityModel>(sender);

                    accountRepo.Update(senderEntity);

                    var senderTransactionEntity = new TransactionEntityModel
                    {
                        AccountId = senderEntity.Id,
                        CurrencyId = sender.CurrencyId,
                        Amount = unconvertedAmount,
                        CreatedById = currentUserId,
                        UniqueTransactionIdentifier = uniqueIdentifier,
                        ToIBAN = toIBAN,
                        TransactionTypeId = (int)TransactionTypeEnum.TransactionType.Credit
                    };

                    _dateService.SetDateCreatedNow(ref senderTransactionEntity);
                    transactionRepo.AddItem(senderTransactionEntity);

                    senderTransactionId = senderTransactionEntity.Id;

                    _unitOfWork.Save();
                    dbTransaction.Commit();
                }
                catch (Exception)
                {
                    senderTransactionId = int.MinValue;
                    dbTransaction.Rollback();
                }
            }

            return senderTransactionId;
        }

        public IEnumerable<FinancialTransactionServiceModel> GetAllTransactions()
        {
            var entities = _unitOfWork.Add<TransactionEntityModel>().GetRepository<TransactionEntityModel>().Get();

            var serviceModels = _mapper.Map<List<FinancialTransactionServiceModel>>(entities);

            return serviceModels;
        }

        public FinancialTransactionServiceModel GetTransactionById(int id)
        {
            var entity = _unitOfWork.Add<TransactionEntityModel>().GetRepository<TransactionEntityModel>().GetById(id);

            var serviceModel = _mapper.Map<FinancialTransactionServiceModel>(entity);

            return serviceModel;
        }
    }
}
