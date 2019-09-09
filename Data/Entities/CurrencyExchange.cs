using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    public class CurrencyExchangeEntityModel : IBaseModel
    {
        public int Id { get; set; }

        [ForeignKey("FromCurrency")]
        public int FromCurrencyId { get; set; }
        public CurrencyEntityModel FromCurrency { get; set; }

        [ForeignKey("ToCurrency")]
        public int ToCurrencyId { get; set; }
        public CurrencyEntityModel ToCurrency { get; set; }

        public double Rate { get; set; }
    }
}
