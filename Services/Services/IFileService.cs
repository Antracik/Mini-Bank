using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public interface IFileService
    {
        bool IsImage(IFormFile image);
        bool IsValidFile(IFormFile file);
        int UploadFile(IFormFile file);
    }
}
