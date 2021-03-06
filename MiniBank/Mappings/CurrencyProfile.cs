﻿using AutoMapper;
using Mini_Bank.Models;
using Mini_Bank.Models.ViewModels.SharedViewModels;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Mappings
{
    public class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        {
            CreateMap<CurrencyModel, CurrencyServiceModel>().ReverseMap();
        }
    }
}
