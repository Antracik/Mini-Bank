using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models.ViewModels
{
    public class UploadImageViewModel
    {
        [Required(ErrorMessage = "Please add an image!")]
        public IFormFile Photo { get; set; }
    }
}
