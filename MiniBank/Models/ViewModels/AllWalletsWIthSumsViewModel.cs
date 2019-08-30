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
    }
}
