using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mini_Bank.Models;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Services.Models;
using Data;
using Services.Services;

namespace Mini_Bank.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly INomenclatureService _nomenclatureService;
        private readonly IDataSeedService _dataSeedService;

        public HomeController(ILogger<HomeController> logger, 
                                INomenclatureService nomenclatureService,
                                IDataSeedService dataSeedService,
                                IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _dataSeedService = dataSeedService;
            _nomenclatureService = nomenclatureService;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            //_dataSeedService.SeedDb();

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
