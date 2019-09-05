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
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Mini_Bank.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("[controller]/[action]")]
    public class FileController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public FileController(IFileService fileService,
                              IMapper mapper)
        {
            _fileService = fileService;
            _mapper = mapper;
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
                if (!_fileService.IsImage(image.Photo))
                {
                    ModelState.AddModelError("", "Uploaded file is not an image >:(");
                }

                _fileService.UploadFile(image.Photo);

                return View();
            }

            return View();
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var filesServiceModel = _fileService.GetAllFiles();

            var filesViewModel = _mapper.Map<List<FileDownloadViewModel>>(filesServiceModel);

            return View("ListFiles", filesViewModel);
        }

        [HttpGet("{fileId}")]
        public IActionResult DownloadFile(string fileId)
        {
            var fileServiceModel = _fileService.GetFileByUniqueFileName(fileId, includeFileData: true);

            if(fileServiceModel == null || string.IsNullOrEmpty(fileServiceModel.Data))
            {
                return NotFound();
            }

            byte[] fileData = _fileService.GetFileDataFromB64(fileServiceModel.Data);

            string fileName = Guid.NewGuid().ToString() + fileServiceModel.FileExtension;

            return File(fileData, fileServiceModel.FileContentType , fileName);
        }

    }
}