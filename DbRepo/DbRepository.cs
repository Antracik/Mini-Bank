using Mini_Bank.DbContexts;
using Mini_Bank.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.DbRepo
{
    public class DbRepository<T> : IDbRepository<T> where T : IBaseModel
    {
        private readonly BankContext _bankContext;

        public DbRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }


    }
}
