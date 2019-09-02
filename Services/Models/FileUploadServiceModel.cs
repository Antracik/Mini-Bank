using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    class FileUploadServiceModel
    {
        public IFormFile Photo { get; set; }
    }
}
