using AutoMapper;
using Mini_Bank.Models.ViewModels;
using Mini_Bank.Models.ViewModels.SharedViewModels;
using Mini_Bank.Models.ViewModels.UtilityModels;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Mappings
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<UserTicketViewModel, TicketServiceModel>().ReverseMap();
            CreateMap<TicketRequestViewModel, TicketServiceModel>().ReverseMap();
            CreateMap<TicketTypeViewModel, TicketTypeServiceModel>().ReverseMap();
            CreateMap<TicketStatusViewModel, TicketStatusServiceModel>().ReverseMap();

            //CreateMap<TicketMessageViewModel, TicketMessageServiceModel>().ReverseMap();
        }
    }
}
