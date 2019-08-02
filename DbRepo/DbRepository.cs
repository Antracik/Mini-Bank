using Microsoft.EntityFrameworkCore;
using Mini_Bank.DbContexts;
using Mini_Bank.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.DbRepo
{
    public class DbRepository<T> : IDbRepository<T> where T :class, IBaseModel
    {
        private readonly BankContext _bankContext;

        public DbRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public void AddItem(T item)
        {
            _bankContext.Set<T>().Add(item);
        }

        public void AddRange(IEnumerable<T> rangeList)
        {
            _bankContext.AddRange(rangeList);
        }

        public void Delete(int id)
        {
            T entity = GetById(id);
            _bankContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _bankContext.Set<T>().AsNoTracking().ToList();
        }

        public T GetById(int id)
        {
            return _bankContext.Set<T>().Find(id);
        }

        public int SaveChanges()
        {
            return _bankContext.SaveChanges();
        }

        public void Update(T item)
        {
            _bankContext.Set<T>().Update(item);
        }
    }
}
