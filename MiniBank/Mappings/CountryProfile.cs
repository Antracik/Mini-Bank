using AutoMapper;
using Mini_Bank.Models;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Mappings
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CountryModel, CountryServiceModel>().ReverseMap();
        }
    }
}
