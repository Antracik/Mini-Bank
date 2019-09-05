using AutoMapper;
using FileRepo.Models;
using Mini_Bank.Models;
using Mini_Bank.Models.ViewModels;
using Services.Models;

namespace Mini_Bank.Mappings
{
    public class WalletProfile : Profile
    {
        public WalletProfile()
        {
            CreateMap<WalletModel, WalletRepoModel>().ReverseMap();
            CreateMap<WalletModel, WalletServiceModel>().ReverseMap();
            CreateMap<UserWalletsViewModel, WalletServiceModel>().ForMember(dest => dest.Accounts, opt => opt.MapFrom( src => src.Accounts ))
                                                                 .ReverseMap();
            CreateMap<WalletVerificationListViewModel, WalletServiceModel>().ReverseMap();
            CreateMap<VerifyWalletViewModel, WalletServiceModel>().ReverseMap();
        }
    }
}
