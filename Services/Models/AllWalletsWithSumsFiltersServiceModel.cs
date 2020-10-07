using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class AllWalletsWithSumsFiltersServiceModel
    {
        public List<string> Countries { get; set; }
        public string RegisteredFrom { get; set; }
        public string RegisteredTo { get; set; }
    }
}
