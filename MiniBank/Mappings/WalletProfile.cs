using AutoMapper;
using FileRepo.Models;
using Mini_Bank.Models;
using Services.Models;

namespace Mini_Bank.Mappings
{
    public class WalletProfile : Profile
    {
        public WalletProfile()
        {
            CreateMap<WalletModel, WalletRepoModel>().ReverseMap();
            CreateMap<WalletModel, WalletServiceModel>().ReverseMap();
        }
    }
}
