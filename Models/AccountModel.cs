﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        public string IBAN { get; set; }
        public decimal Balance { get; set; }
        public CurrencyModel.Currency Currency{ get; set; }
        public StatusModel.Status AccountStatus{ get; set; }

        public AccountModel(int id, string iBAN, decimal balance, CurrencyModel.Currency currency, StatusModel.Status accountStatus)
        {
            Id = id;
            IBAN = iBAN;
            Balance = balance;
            Currency = currency;
            AccountStatus = accountStatus;
        }
    }
}