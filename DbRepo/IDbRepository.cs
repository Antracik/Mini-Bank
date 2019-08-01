using Mini_Bank.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.DbRepo
{
    interface IDbRepository<T> where T : IBaseModel
    {
        
    }
}
