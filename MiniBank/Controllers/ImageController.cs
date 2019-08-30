using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mini_Bank.Models.ViewModels;
using Mini_Bank.Extensions;
using Microsoft.AspNetCore.Http;
using Services.Services;
using static System.Net.Mime.MediaTypeNames;

namespace Mini_Bank.Controllers
{
    [Route("[controller]/[action]")]
    public class ImageController : Controller
    {
        private readonly IFileService _imageService;

        public ImageController(IFileService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        public IActionResult UploadPhoto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadPhoto( UploadImageViewModel image )
        {
            if(ModelState.IsValid)
            {
                if (!_imageService.IsImage(image.Photo))
                {
                    ModelState.AddModelError("", "Uploaded file is not an image >:(");
                }

                _imageService.UploadFile(image.Photo);

                return View();
            }

            return View();
        }
    }
}