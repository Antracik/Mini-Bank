using AutoMapper;
using FileRepo.Models;
using Mini_Bank.Models;
using Services.Models;

namespace Mini_Bank.Mappings
{
    public class RegistrantProfile : Profile
    {
        public RegistrantProfile()
        {
            CreateMap<RegistrantModel, RegistrantRepoModel>().ReverseMap();
            CreateMap<RegistrantModel, RegistrantServiceModel>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.CountryId))
                .ForMember(dest => dest.CountryRelation, opt => opt.MapFrom(src => src.CountryModel))
                .ReverseMap();

        }
    }
}
