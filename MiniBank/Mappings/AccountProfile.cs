using AutoMapper;
using Mini_Bank.FileRepo.Models;
using Mini_Bank.Models;
using Services.Models;

namespace Mini_Bank.Mappings
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountRepoModel, AccountModel>().ReverseMap();
            CreateMap<AccountModel, AccountServiceModel>()
                .ForMember(dest => dest.CurrencyRelation, opt => opt.MapFrom(src => src.Currency))
                .ReverseMap();
        }
    }
}
