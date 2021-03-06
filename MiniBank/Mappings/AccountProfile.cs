﻿using AutoMapper;
using FileRepo.Models;
using Mini_Bank.Models;
using Mini_Bank.Models.ViewModels;
using Mini_Bank.Models.ViewModels.UtilityModels;
using Services.Models;

namespace Mini_Bank.Mappings
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            //CreateMap<AccountRepoModel, AccountModel>().ReverseMap();
            CreateMap<AccountModel, AccountServiceModel>()
                .ForMember(dest => dest.CurrencyRelation, opt => opt.MapFrom(src => src.Currency))
                .ReverseMap();

            CreateMap<AccountServiceModel, UserWalletAccounts>()
                .ForPath( dest => dest.Currency, opt => opt.MapFrom( src => src.CurrencyRelation))
                .ReverseMap();

            CreateMap<AccountServiceModel, VerifyWalletAccounts>()
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.CurrencyRelation))
                .ReverseMap();

            CreateMap<AccountServiceModel, AccountDetailsViewModel>()
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.CurrencyRelation))
                .ForMember(dest => dest.AccountStatus, opt => opt.MapFrom(src => src.Status))
                .ReverseMap();

            CreateMap<AccountServiceModel, AccountInputModel>()
                .ReverseMap();
        }
    }
}
