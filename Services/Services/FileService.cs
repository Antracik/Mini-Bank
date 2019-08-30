using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;

namespace Services.Services
{
    public class FileService : IFileService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IDateService _dateService;

        public FileService(UnitOfWork unitOfWork, IDateService dateService) 
        {
            _unitOfWork = unitOfWork;
            _dateService = dateService;
        }

        public bool IsValidFile(IFormFile file)
        {
            string fileName = file.FileName;

            bool isValid = !string.IsNullOrEmpty(fileName) &&
              fileName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0;

            return isValid;
        }

        public bool IsImage(IFormFile image)
        {
            string contentType = image.ContentType.ToLower();
            string extension = Path.GetExtension(image.FileName).ToLower();

            if (contentType != "image/jpg" &&
                contentType != "image/jpeg" &&
                contentType != "image/pjpeg" &&
                contentType != "image/gif" &&
                contentType != "image/x-png" &&
                contentType != "image/png")
            {
                return false;
            }

            if (extension != ".jpg" &&
                extension != ".png" &&
                extension != ".gif" &&
                extension != ".jpeg")
            {
                return false;
            }

            return true;
        }

        private FileDescriptorEntityModel GetFileDescription(IFormFile file)
        {
            var fileDescriptor = new FileDescriptorEntityModel();

            fileDescriptor.FileName = Path.GetFileNameWithoutExtension(file.FileName);
            fileDescriptor.FileExtension = Path.GetExtension(file.FileName);
            fileDescriptor.UniqueFileName = Guid.NewGuid().ToString() + "_" + fileDescriptor.FileName + fileDescriptor.FileExtension;
            _dateService.SetDateCreatedNow(ref fileDescriptor);

            return fileDescriptor;
        }

        private byte[] GetFileData(IFormFile file)
        {
            byte[] fileData;

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);

                fileData = ms.ToArray();
            }

            return fileData;
        }

        private byte[] GetFileDataFromBase64(string base64String)
        {
            return Convert.FromBase64String(base64String);
        }

        public int UploadFile(IFormFile inputFile)
        {
            var fileData = GetFileData(inputFile);

            using (var transaction = _unitOfWork.BankContext.Database.BeginTransaction())
            {
                try
                {
                    var file = new FileEntityModel();

                    file.Data = Convert.ToBase64String(fileData);

                    var fileDescriptor = GetFileDescription(inputFile);

                    //Try adding file
                    _unitOfWork.Add<FileEntityModel>().GetRepository<FileEntityModel>().AddItem(file);
                    _unitOfWork.Save();

                    //If file is added, it now has an Id and we must add it to the file descriptor
                    fileDescriptor.FileId = file.Id;

                    _unitOfWork.Add<FileDescriptorEntityModel>().GetRepository<FileDescriptorEntityModel>().AddItem(fileDescriptor);
                    _unitOfWork.Save();

                    //If we get this far, all should be good!
                    transaction.Commit();

                    return file.Id;
                }
                catch(Exception)
                {
                    transaction.Rollback();
                    return int.MinValue;
                }
            }
        }
    }
}
