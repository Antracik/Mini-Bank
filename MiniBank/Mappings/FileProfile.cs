using AutoMapper;
using Mini_Bank.Models.ViewModels;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Mappings
{
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<FileDownloadViewModel, FileDownloadServiceModel>().ReverseMap();
        }
    }
}
