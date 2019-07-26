using AutoMapper;
using Mini_Bank.FileRepo.Models;
using Mini_Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Mappings
{
    public class WalletProfile : Profile
    {
        public WalletProfile()
        {
            CreateMap<WalletModel, WalletRepoModel>().ReverseMap();
        }
    }
}
