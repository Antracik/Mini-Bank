using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mini_Bank.Models;

namespace Mini_Bank.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DetailsUser(int id)
        {
            return View(Generate.GetUsers().FirstOrDefault(user => user.Id == id));
        }

        public IActionResult DisplayUsers()
        {
            return View(Generate.GetUsers());
        }
    }
}