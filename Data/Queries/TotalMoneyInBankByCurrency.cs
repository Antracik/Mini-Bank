using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Queries
{
    public class TotalMoneyInBankByCurrency : BaseQuery, IBaseModel
    {
        [NotMapped]
        public int Id { get; set; }

        public decimal Total { get; set; }
        public string Currency { get; set; }
    }

    public static class TotalMoneyInBankByCurrencyExtension
    {
        public static string GetQuery(this TotalMoneyInBankByCurrency item)
        {
            return @"SELECT 
                     SUM(ac.Balance) AS Total, 
                     cur.[Name] AS Currency FROM Account AS ac
                     INNER JOIN Currency AS cur ON cur.Id = ac.CurrencyId
                     GROUP BY cur.[Name]";
        }
    }
}
