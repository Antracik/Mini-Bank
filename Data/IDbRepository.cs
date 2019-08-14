using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data
{
    public interface IDbRepository<T> where T : IBaseModel 
    {
        void AddRange(IEnumerable<T> rangeList);
        void AddItem(T item);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        T GetById(int id);
        void Update(T item);
        void Delete(int id);

    }
}
