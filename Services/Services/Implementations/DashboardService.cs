using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Data;
using Data.Queries;
using Services.Models;
using System.Linq;

namespace Services.Services.Implementations
{
    public class DashboardService : IDashboardService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardService(UnitOfWork unitOfWork,
                                IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<NewUsersIn30DaysServiceModel> GetNewUsersIn30Days()
        {
            var entity = _unitOfWork.Add<NewUsersIn30Days>()
                                    .GetRepository<NewUsersIn30Days>()
                                    .FromSQL(new NewUsersIn30Days().GetQuery());

            var temp = _mapper.Map<List<NewUsersIn30DaysServiceModel>>(entity);

            var serviceModel = new List<NewUsersIn30DaysServiceModel>();

            int index = 0;
            for (int i = 1; i <= 30; i++)
            {
                if (temp.Any(x => x.Day == i))
                {
                    serviceModel.Add(new NewUsersIn30DaysServiceModel { Day = i, UserCount = temp[index].UserCount });
                    index++;
                }
                else
                {
                    serviceModel.Add(new NewUsersIn30DaysServiceModel { Day = i, UserCount = 0 });
                } 
            }


            return serviceModel;    
        }
    }
}
