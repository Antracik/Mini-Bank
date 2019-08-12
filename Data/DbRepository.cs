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
    public class DbRepository<T> : IDbRepository<T> where T :class, IBaseModel
    {
        private readonly BankContext _bankContext;
        //private static readonly Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public DbRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public void AddItem(T item)
        {
            //LogEventInfo eventInfo = new LogEventInfo { Level = NLog.LogLevel.Info };

            _bankContext.Set<T>().Add(item);

            //eventInfo.Properties["AddedItem"] = item;

            //_logger.Log(eventInfo);
        }

        public void AddRange(IEnumerable<T> rangeList)
        {
            _bankContext.AddRange(rangeList);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);

            //LogEventInfo eventInfo = new LogEventInfo { Level = NLog.LogLevel.Info };

            //eventInfo.Properties["DeletedItem"] = entity;

            _bankContext.Set<T>().Remove(entity);

            //_logger.Info(eventInfo);
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

            //LogEventInfo eventInfo = new LogEventInfo { Level = NLog.LogLevel.Info };

            //var oldItem = _bankContext.Set<T>().AsNoTracking().FirstOrDefault(ent => ent.Id == item.Id);

            //eventInfo.Properties["NewValue"] = item;
            //eventInfo.Properties["OldValue"] = oldItem;

            _bankContext.Set<T>().Update(item);

            //_logger.Log(eventInfo);

        }

    }
}
