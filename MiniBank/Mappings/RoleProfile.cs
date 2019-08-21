using AutoMapper;
using Data.Entities;
using Mini_Bank.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleViewModel, RoleModel>().ReverseMap();
            CreateMap<EditRoleViewModel, RoleModel>().ReverseMap();
        }
    }
}
