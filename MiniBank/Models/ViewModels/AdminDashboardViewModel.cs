using Mini_Bank.Models.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models.ViewModels
{
    public class AdminDashboardViewModel
    {
        public NewUsersIn30DaysChart NewUsers { get; set; }
        public TotalMoneyInBankByCurrencyChart TotalMoney { get; set; }
    }
}
