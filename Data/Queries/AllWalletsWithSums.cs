using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Queries
{
    public class AllWalletsWithSums : BaseQuery, IBaseModel
    {
        public int Id { get; set; }
        public string ClienName { get; set; }
        public CountryEnum.Countries ClienCountry { get; set; }
        public double Amount { get; set; }
        public Shared.CurrencyEnum.Currency Currency { get; set; }
    }

    public static class AllWalletsWithSumsExtension
    {
        public static string GetQuery(this AllWalletsWithSums item)
        {
            return @"Select 
                            ID, ClienName, ClienCountry, Amount, Currency
                            from ALA BALA";

        }
    }

}
