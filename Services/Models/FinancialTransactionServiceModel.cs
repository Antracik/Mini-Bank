using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class FinancialTransactionServiceModel
    {
        public int Id { get; set; }

        public int AccountId { get; set; }
        public AccountServiceModel Account { get; set; }
        public string UniqueTransactionIdentifier { get; set; }

        public string ToIBAN { get; set; }

        public decimal Amount { get; set; }

        public int CurrencyId { get; set; }
        public CurrencyServiceModel Currency { get; set; }

        public int TransactionTypeId { get; set; }
        public FinancialTransactionTypeServiceModel TransactionType { get; set; }

        public int? CreatedById { get; set; }
        public UserServiceModel CreatedByUser { get; set; }
        public DateTime DateCreated { get; set; }

        public int? EditedById { get; set; }
        public UserServiceModel EditedByUser { get; set; }
        public DateTime? DateEdited { get; set; }
    }
}
