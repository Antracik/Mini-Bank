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
        }
    }
}
