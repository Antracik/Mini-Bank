using Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Mini_Bank.Models.ViewModels
{
    public class AllWalletsWithSumsViewModel
    {
        public AllWalletsWithSumsFilters Filters { get; set; }
        public IPagedList<AllWalletsWithSums> Data { get; set; }
        public int CurrentPage { get; set; }
        public string CurrentSort { get; set; }
        public List<CountryModel> Countries { get; set; }

        public string IdSort { get; set; }
        public string ClientNameSort { get; set; }
        public string ClientCountrySort { get; set; }
        public string BalanceSort { get; set; }
        public string CurrencySort { get; set; }

    }
}
