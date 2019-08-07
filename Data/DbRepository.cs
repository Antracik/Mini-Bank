using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Data
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

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _bankContext.Set<T>().AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public T GetById(int id)
        {
            return _bankContext.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            _bankContext.Set<T>().Update(item);
        }

    }
}
