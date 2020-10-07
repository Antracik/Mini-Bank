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
        public HomeController()
        {
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
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
