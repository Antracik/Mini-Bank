using AutoMapper;
using Data.Entities;
using Data.Queries;
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
            CreateMap<AccountServiceModel, AccountEntityModel>().ReverseMap();

            CreateMap<UserServiceModel, UserEntityModel>().ReverseMap();

            CreateMap<RegistrantServiceModel, RegistrantEntityModel>().ReverseMap();

            CreateMap<WalletServiceModel, WalletEntityModel>().ReverseMap();

            CreateMap<CountryServiceModel, CountryEntityModel>().ReverseMap();

            CreateMap<StatusServiceModel, StatusEntityModel>().ReverseMap();

            CreateMap<CurrencyServiceModel, CurrencyEntityModel>().ReverseMap();

            CreateMap<FileDownloadServiceModel, FileEntityModel>().ForPath( dest => dest.Descriptor.FileName, opt => opt.MapFrom( src => src.FileName ) )
                                                                  .ForPath( dest => dest.Descriptor.FileExtension, opt => opt.MapFrom(src => src.FileExtension))
                                                                  .ForPath(dest => dest.Descriptor.UniqueFileName, opt => opt.MapFrom(src => src.UniqueFileName))
                                                                  .ForPath(dest => dest.Descriptor.FileContentType, opt => opt.MapFrom(src => src.FileContentType))
                                                                  .ReverseMap();

            CreateMap<FileDownloadServiceModel, FileDescriptorEntityModel>().ForPath(dest => dest.File.Data, opt => opt.MapFrom( src => src.Data ))
                                                                            .ReverseMap();

            CreateMap<FinancialTransactionTypeServiceModel, TransactionTypeEntityModel>().ReverseMap();

            CreateMap<FinancialTransactionServiceModel, TransactionEntityModel>().ReverseMap();

            CreateMap<NewUsersIn30DaysServiceModel, NewUsersIn30Days>().ReverseMap();

            CreateMap<UserTotalMoneyByCurrencyServiceModel, UserTotalMoneyByCurrency>().ReverseMap();

            CreateMap<TotalMoneyInBankByCurrencyServiceModel, TotalMoneyInBankByCurrency>().ReverseMap();

            CreateMap<TicketStatusServiceModel, TicketStatusEntityModel>().ReverseMap();

            CreateMap<TicketTypeServiceModel, TicketTypeEntityModel>().ReverseMap();

            CreateMap<TicketMessageServiceModel, TicketMessageEntityModel>().ReverseMap();

            CreateMap<TicketServiceModel, TicketEntityModel>().ReverseMap();
        }
    }
}
