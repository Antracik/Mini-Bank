using AutoMapper;
using Mini_Bank.DbRepo.Entities;
using Mini_Bank.FileRepo.Models;
using Mini_Bank.Models;

namespace Mini_Bank.Mappings
{
    public class WalletProfile : Profile
    {
        public WalletProfile()
        {
            CreateMap<WalletModel, WalletRepoModel>().ReverseMap();
            CreateMap<WalletModel, WalletDbRepoModel>().ReverseMap();
        }
    }
}
