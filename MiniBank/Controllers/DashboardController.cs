using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;
using Mini_Bank.Models.Charts;
using Mini_Bank.Models.ViewModels;
using Newtonsoft.Json;
using Services.Services;

namespace Mini_Bank.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;
        private readonly IUserService _userService;

        public DashboardController(IDashboardService dashboardService,
                                    IUserService userService)
        {
            _userService = userService;
            _dashboardService = dashboardService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminDashboard()
        {
            var newUsers = _dashboardService.GetNewUsersIn30Days();
            var totalMoney = _dashboardService.GetTotalMoneyInBankByCurrency();

            var model = new AdminDashboardViewModel
            {
                NewUsers = new NewUsersIn30DaysChart
                {
                    JsonData = JsonConvert.SerializeObject(newUsers)
                },
                TotalMoney = new TotalMoneyInBankByCurrencyChart
                {
                    JsonData = JsonConvert.SerializeObject(totalMoney)
                }
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult UserDashboard()
        {
            int userId = int.Parse(_userService.GetUserId(User));
            var totalMoney = _dashboardService.GetTotalMoneyByCurrencyForUser(userId);

            var model = new UserDashboardViewModel
            {
                TotalMoneyByCurrency = new UserTotalMoneyByCurrencyChart
                    {
                        JsonData = JsonConvert.SerializeObject(totalMoney)
                    }
            };

            return View(model);
        }

    }
}