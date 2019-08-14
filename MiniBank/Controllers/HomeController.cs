using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mini_Bank.Models;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Services.Models;

namespace Mini_Bank.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly INomenclatureService _nomenclatureService;

        public HomeController(ILogger<HomeController> logger, 
                                INomenclatureService nomenclatureService, 
                                IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _nomenclatureService = nomenclatureService;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            //DataSeeder seed = new DataSeeder(_bankContext);
            //seed.SeedDatabase();

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
