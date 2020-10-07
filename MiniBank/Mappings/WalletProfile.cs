using AutoMapper;
using FileRepo.Models;
using Mini_Bank.Models;
using Mini_Bank.Models.ViewModels;
using Mini_Bank.Models.ViewModels.UtilityModels;
using Services.Models;

namespace Mini_Bank.Mappings
{
    public class WalletProfile : Profile
    {
        public WalletProfile()
        {
            CreateMap<WalletModel, WalletServiceModel>().ReverseMap();

            CreateMap<UserWallets, WalletServiceModel>()
                .ForMember(dest => dest.Accounts, opt => opt.MapFrom( src => src.Accounts ))
                .ReverseMap();

            CreateMap<WalletVerificationListViewModel, WalletServiceModel>().ReverseMap();

            CreateMap<VerifyWalletViewModel, WalletServiceModel>().ReverseMap();
        }
    }
}
