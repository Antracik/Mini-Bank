using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Services.Models;
using AutoMapper;

namespace Services.Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IDateService _dateService;
        private readonly IMapper _mapper;

        public FileService(UnitOfWork unitOfWork, 
                          IDateService dateService,
                          IMapper mapper) 
        {
            _mapper = mapper;
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
            var fileDescriptor = new FileDescriptorEntityModel
            {
                FileName = Path.GetFileNameWithoutExtension(file.FileName),
                FileExtension = Path.GetExtension(file.FileName),
                FileContentType = file.ContentType
            };
            fileDescriptor.UniqueFileName = Guid.NewGuid().ToString() + "_" + fileDescriptor.FileName + fileDescriptor.FileExtension;

            _dateService.SetDateCreatedNow(ref fileDescriptor);

            return fileDescriptor;
        }

        public FileDownloadServiceModel GetFileById(int fileId, bool includeFileData = false)
        {
            string include = includeFileData ? "File" : "";

            var file = _unitOfWork.Add<FileDescriptorEntityModel>()
                                  .GetRepository<FileDescriptorEntityModel>()
                                  .Get(x => x.Id == fileId, null, include)
                                  .FirstOrDefault();

            var serviceFile = _mapper.Map<FileDownloadServiceModel>(file);

            return serviceFile;
        }

        public IEnumerable<FileDownloadServiceModel> GetAllFiles(bool includeFileData = false)
        {
            string include = includeFileData ? "File" : "";

            var files = _unitOfWork.Add<FileDescriptorEntityModel>()
                                  .GetRepository<FileDescriptorEntityModel>()
                                  .Get(includeProperties: include);

            var serviceFiles = _mapper.Map<List<FileDownloadServiceModel>>(files);

            return serviceFiles;
        }

        public FileDownloadServiceModel GetFileByUniqueFileName(string uniqueFileName, bool includeFileData = false)
        {
            string include = includeFileData ? "File" : "";

            var file = _unitOfWork.Add<FileDescriptorEntityModel>()
                                  .GetRepository<FileDescriptorEntityModel>()
                                  .Get(x => x.UniqueFileName == uniqueFileName, null, include)
                                  .FirstOrDefault();

            var serviceFile = _mapper.Map<FileDownloadServiceModel>(file);

            return serviceFile;
        }

        public byte[] GetFileDataFromB64(string fileBase64Data)
        {
            return Convert.FromBase64String(fileBase64Data);
        }

        public int UploadFile(IFormFile inputFile)
        {
            byte[] fileData;

            using (var ms = new MemoryStream())
            {
                inputFile.CopyTo(ms);

                fileData = ms.ToArray();
            }

            using (var transaction = _unitOfWork.BankContext.Database.BeginTransaction())
            {
                try
                {
                    var file = new FileEntityModel
                    {
                        Data = Convert.ToBase64String(fileData)
                    };

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
