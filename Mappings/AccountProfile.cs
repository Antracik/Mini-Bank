using AutoMapper;
using Mini_Bank.DbRepo.Entities;
using Mini_Bank.FileRepo.Models;
using Mini_Bank.Models;

namespace Mini_Bank.Mappings
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountRepoModel, AccountModel>().ReverseMap();
            CreateMap<AccountModel, AccountDbRepoModel>()
                .ForMember(dest => dest.CurrencyRelation, opt => opt.MapFrom(src => src.Currency))
                .ReverseMap();
        }
    }
}
