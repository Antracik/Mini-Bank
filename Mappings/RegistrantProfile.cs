using AutoMapper;
using Mini_Bank.DbRepo.Entities;
using Mini_Bank.FileRepo.Models;
using Mini_Bank.Models;

namespace Mini_Bank.Mappings
{
    public class RegistrantProfile : Profile
    {
        public RegistrantProfile()
        {
            CreateMap<RegistrantModel, RegistrantRepoModel>().ReverseMap();
            CreateMap<RegistrantModel, RegistrantDbRepoModel>().ReverseMap();
        }
    }
}
