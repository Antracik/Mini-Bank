using AutoMapper;
using Mini_Bank.FileRepo.Models;
using Mini_Bank.Models;
using Services.Models;

namespace Mini_Bank.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserModel, UserRepoModel>().ReverseMap();
            CreateMap<UserModel, UserServiceModel>().ReverseMap();
        }
    }
}
