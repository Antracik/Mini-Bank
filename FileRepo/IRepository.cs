using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_Bank.Models.ViewModels;

namespace Mini_Bank.FileRepo
{
    public interface IRepository<T> where T : IBaseModel
    {
        void AddItem(T item);
        void AddRange(IEnumerable<T> rangeList);
        IEnumerable<T> Get();
        void SaveChanges();
        void Clear();
        void Reset();
    }
}
