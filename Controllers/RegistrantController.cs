using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mini_Bank.Models;

namespace Mini_Bank.Controllers
{
    public class RegistrantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DetailsRegistrant(int id)
        {
            return View(Generate.GetRegistrants().FirstOrDefault(registrant => registrant.Id == id));
        }

        public IActionResult DisplayRegistrants()
        {
            return View(Generate.GetRegistrants());
        }

    }
}