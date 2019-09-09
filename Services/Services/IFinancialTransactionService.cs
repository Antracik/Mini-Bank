using Services.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Services.Services
{
    public interface IFinancialTransactionService
    {
        FinancialTransactionServiceModel GetTransactionById(int id);
        IEnumerable<FinancialTransactionServiceModel> GetAllTransactions();
        int AddTransaction(FinancialTransactionServiceModel transaction);
        int EnactTransaction(AccountServiceModel sender, decimal amount, int currentUserId, string toIBAN, AccountServiceModel recipient = null);
    }
}
