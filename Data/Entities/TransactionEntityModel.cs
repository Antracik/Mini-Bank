using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("Transactions")]
    public class TransactionEntityModel : IBaseHistory
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public AccountEntityModel Account{ get; set; }

        public string ToIBAN { get; set; }

        public decimal Amount { get; set; }

        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }
        public CurrencyEntityModel Currency { get; set; }

        [ForeignKey("CreatedByUser")]
        public int? CreatedById { get; set; }
        public UserEntityModel CreatedByUser { get; set; }
        public DateTime DateCreated { get; set; }

        [ForeignKey("EditedByUser")]
        public int? EditedById { get; set; }
        public UserEntityModel EditedByUser { get; set; }
        public DateTime? DateEdited { get; set; }
    }
}
