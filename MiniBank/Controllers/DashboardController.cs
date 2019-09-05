using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;

namespace Mini_Bank.Controllers
{
    public class AgeInfo
    {

        public string age;
        public int population;

        public AgeInfo(string prmAge, int prmPop)
        {
            this.age = prmAge;
            this.population = prmPop;
        }

    }

    public class DashboardController : Controller
    {
        private readonly INodeServices _nodeServices;

        public DashboardController(INodeServices nodeServices)
        {
            _nodeServices = nodeServices;
        }

        public IActionResult Index()
        {
            var options = new { width = 400, height = 200 };

            List<AgeInfo> ls = new List<AgeInfo>();
            ls.Add(new AgeInfo("<5", 2704659));
            ls.Add(new AgeInfo("5-13", 4499890));
            ls.Add(new AgeInfo("14-17", 2159981));
            ls.Add(new AgeInfo("18-24", 3853788));
            ls.Add(new AgeInfo("25-44", 14106543));
            ls.Add(new AgeInfo("45-64", 8819342));
            ls.Add(new AgeInfo("≥65", 612463));

            //ViewData["Chart"] = await _nodeServices.InvokeAsync<string>("NodeChart.js", options, ls);

            return View("Chart");
        }
    }
}