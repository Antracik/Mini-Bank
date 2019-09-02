using AutoMapper;
using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    class SetupMappingProfile : Profile
    {
        public SetupMappingProfile()
        {
            CreateMap<AccountServiceModel, AccountDbRepoModel>().ReverseMap();

            CreateMap<UserServiceModel, UserDbRepoModel>().ReverseMap();

            CreateMap<RegistrantServiceModel, RegistrantDbRepoModel>().ReverseMap();

            CreateMap<WalletServiceModel, WalletDbRepoModel>().ReverseMap();

            CreateMap<CountryServiceModel, CountryDbRepoModel>().ReverseMap();

            CreateMap<StatusServiceModel, StatusDbRepoModel>().ReverseMap();

            CreateMap<CurrencyServiceModel, CurrencyDbRepoModel>().ReverseMap();

            CreateMap<FileDownloadServiceModel, FileEntityModel>().ForPath( dest => dest.Descriptor.FileName, opt => opt.MapFrom( src => src.FileName ) )
                                                                  .ForPath( dest => dest.Descriptor.FileExtension, opt => opt.MapFrom(src => src.FileExtension))
                                                                  .ForPath(dest => dest.Descriptor.UniqueFileName, opt => opt.MapFrom(src => src.UniqueFileName))
                                                                  .ForPath(dest => dest.Descriptor.FileContentType, opt => opt.MapFrom(src => src.FileContentType))
                                                                  .ReverseMap();

            CreateMap<FileDownloadServiceModel, FileDescriptorEntityModel>().ForPath(dest => dest.File.Data, opt => opt.MapFrom( src => src.Data ))
                                                                            .ReverseMap();

        }
    }
}
