using AutoMapper;
using FileRepo.Models;
using Mini_Bank.Models;
using Mini_Bank.Models.ViewModels;
using Services.Models;
using System.Linq;

namespace Mini_Bank.Mappings
{
    public class RegistrantProfile : Profile
    {
        public RegistrantProfile()
        {
            //CreateMap<RegistrantModel, RegistrantRepoModel>().ReverseMap();
            CreateMap<RegistrantModel, RegistrantServiceModel>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.CountryId))
                .ForMember(dest => dest.CountryRelation, opt => opt.MapFrom(src => src.CountryModel))
                .ForMember(dest => dest.Wallets, opt => opt.MapFrom(src => src.Wallets))
                .ReverseMap();

            CreateMap<RegistrantDetailsViewModel, RegistrantServiceModel>()
                .ForMember(dest => dest.CountryRelation, opt => opt.MapFrom(src => src.Country))
                .ReverseMap();
        }
    }
}
