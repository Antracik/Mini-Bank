using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mini_Bank.Models;

namespace Mini_Bank.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = "An internal error occured" });
        }
    }
}