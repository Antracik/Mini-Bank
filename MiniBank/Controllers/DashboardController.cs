using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;
using Mini_Bank.Models.Charts;
using Newtonsoft.Json;
using Services.Services;

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
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public IActionResult Index()
        {
            var serviceModel = _dashboardService.GetNewUsersIn30Days();

            var model = new NewUsersIn30DaysChart { JsonData = JsonConvert.SerializeObject(serviceModel) }; 

            return View("Chart", model);
        }
    }
}