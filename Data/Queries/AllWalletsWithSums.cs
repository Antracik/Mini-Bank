using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Queries
{
    public class AllWalletsWithSums : BaseQuery, IBaseModel
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ClientCountry { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
    }
    
    public static class AllWalletsWithSumsExtension
    {
        public static string GetQuery(this AllWalletsWithSums item)
        {
            return @"SELECT acc.[Id], 
                        reg.[FirstName] + ' ' + reg.[LastName] AS ClientName, 
                        cnt.[Name] AS ClientCountry, 
                        acc.[Balance] , 
                        cur.[Name] AS Currency
                        FROM Registrant AS reg
                        INNER JOIN Wallet AS wal ON wal.RegistrantId = reg.Id
                        INNER JOIN Account AS acc ON acc.WalletId = wal.Id
                        INNER JOIN Currency AS cur ON cur.Id = acc.CurrencyId
                        INNER JOIN Country AS cnt ON cnt.Id = reg.CountryId";
        }
    }

}
