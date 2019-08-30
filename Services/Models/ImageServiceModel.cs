using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    class ImageServiceModel
    {
        public IFormFile Photo { get; set; }
    }
}
