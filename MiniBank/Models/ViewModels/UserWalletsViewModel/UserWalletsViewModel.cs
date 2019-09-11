using Mini_Bank.Models.ViewModels.UtilityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models.ViewModels
{
    public class UserWalletsViewModel
    {
        public List<UserWallets> Wallets { get; set; }
        public UserWalletTransaction InputTransaction { get; set; }
        public string Message{ get; set; }
    }

}
