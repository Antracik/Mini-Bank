using Mini_Bank.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.DbRepo
{
    public interface IDbRepository<T> where T : IBaseModel
    {
        void AddRange(IEnumerable<T> rangeList);
        void AddItem(T item);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Update(T item);
        void Delete(int id);
        int SaveChanges();

    }
}
