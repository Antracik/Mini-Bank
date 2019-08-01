using AutoMapper;
using Mini_Bank.DbRepo.Entities;
using Mini_Bank.FileRepo.Models;
using Mini_Bank.Models;

namespace Mini_Bank.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserModel, UserRepoModel>().ReverseMap();
            CreateMap<UserModel, UserDbRepoModel>().ReverseMap();
        }
    }
}
