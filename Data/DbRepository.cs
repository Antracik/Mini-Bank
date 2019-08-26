using Data.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using NLog;
using Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace Data
{
    public class DbRepository<T> : IDbRepository<T> where T : class, IBaseModel
    {
        private readonly BankContext _bankContext;
        private readonly DbSet<T> _dbSet;
        private readonly DbQuery<T> _dbQuery;

        //private static readonly Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public DbRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
            if (typeof(T).BaseType == typeof(BaseQuery))
            {
                _dbQuery = _bankContext.Query<T>();
            }
            else
            {
                _dbSet = _bankContext.Set<T>();
            }
        }

        public IEnumerable<T> FromSQL(string rawSQL, Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            params object[] parameters)
        {
            var query =  _dbQuery.FromSql(rawSQL, parameters);

            return ApplyFiltersInQuerybleObj(query, filter, orderBy, includeProperties);
        }

        public void AddItem(T item)
        {
            _dbSet.Add(item);
        }

        public void AddRange(IEnumerable<T> rangeList)
        {
            _bankContext.AddRange(rangeList);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _dbSet.Remove(entity);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _bankContext.Set<T>().AsNoTracking();

            return ApplyFiltersInQuerybleObj(query, filter, orderBy, includeProperties);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T item)
        {
            _dbSet.Update(item);
        }

        private IEnumerable<T> ApplyFiltersInQuerybleObj(IQueryable<T> query, Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
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


    }
}
