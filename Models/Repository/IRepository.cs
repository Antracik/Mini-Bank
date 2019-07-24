using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_Bank.Models.ViewModels;

namespace Mini_Bank.Models.Repository
{
    public interface IRepository<T> where T : IBaseModel
    {
        void AddItem(T item);
        void AddRange(IEnumerable<T> rangeList);
        List<T> Read();
        List<T> GetCachedRepo();
    }
}
