using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mini_Bank.Models;
using Mini_Bank.Extensions;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Services.Models;
using Data;
using Services.Services;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data.Queries;
using System.Linq;
using Shared;

namespace Mini_Bank.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IDataSeedService _dataSeedService;

        // testing, remove later//
        private readonly UnitOfWork _unitOfWork;

        public HomeController(IDataSeedService dataSeedService, UnitOfWork unitOfWork)
        {
            _dataSeedService = dataSeedService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            //_dataSeedService.SeedDb();

            _unitOfWork.Add<AllWalletsWithSums>();

            var walletsWithSums = new AllWalletsWithSums();

            var test = _unitOfWork.GetRepository<AllWalletsWithSums>().
                                    FromSQL(walletsWithSums.GetQuery(), x => x.Currency.Equals(CurrencyEnum.Currency.BGN.ToString()),
                                            z => z.OrderBy(y => y.ClientName))
                                    .ToList();

            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
