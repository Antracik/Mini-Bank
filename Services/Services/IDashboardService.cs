using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public interface IDashboardService
    {
        IEnumerable<NewUsersIn30DaysServiceModel> GetNewUsersIn30Days();
    }
}
