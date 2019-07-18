using System.Linq;
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