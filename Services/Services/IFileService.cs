using Data.Entities;
using Microsoft.AspNetCore.Http;
using Services.Models;
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
        byte[] GetFileDataFromB64(string fileBase64Data);
        FileDownloadServiceModel GetFileById(int fileId, bool includeFileData = false);
        FileDownloadServiceModel GetFileByUniqueFileName(string uniqueFileName, bool includeFileData = false);
        IEnumerable<FileDownloadServiceModel> GetAllFiles(bool includeFileData = false);
    }
}
