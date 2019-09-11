using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models.ViewModels.UtilityModels
{
    public class AllWalletsWithSumsFilters
    {
        public List<string> Countries{ get; set; }
        public string RegisteredFrom { get; set; }
        public string RegisteredTo { get; set; }
    }
}
