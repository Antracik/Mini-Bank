using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Queries
{
    public class UserTotalMoneyByCurrency : BaseQuery, IBaseModel
    {
        [NotMapped]
        public int Id { get; set; }

        public decimal Total  { get; set; }
        public string Currency { get; set; }
    }

    
    public static class UserTotalMoneyByCurrencyExtension
    {
        public static string GetQuery(this UserTotalMoneyByCurrency item, int userId)
        {
            return $@"SELECT 
                        SUM(ac.Balance) AS Total, 
                        cur.[Name] AS Currency 
                        FROM Account AS ac
                        INNER JOIN Currency AS cur ON cur.Id = ac.CurrencyId
                        INNER JOIN Wallet AS wal ON wal.Id = ac.WalletId
                        INNER JOIN Registrant AS reg ON reg.Id = wal.RegistrantId
                        WHERE reg.UserId = {userId}
                        GROUP BY  cur.[Name]";
        }
    }
}
