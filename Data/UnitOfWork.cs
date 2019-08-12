using Shared;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.Linq;

namespace Data
{ 
    public class UnitOfWork : IDisposable
    { 

        private readonly BankContext _context;
        private readonly List<object> _repos = new List<object>(); 

        public UnitOfWork(BankContext context)
        {
            _context = context;
        }

        public UnitOfWork Add<T>() where T : class, IBaseModel
        {
            DbRepository<T> repo = new DbRepository<T>(_context);
            _repos.Add(repo);
            return this;
        }

        public DbRepository<T> GetRepository<T>() where T : class, IBaseModel
        {
            foreach(object repo in _repos)
            {
                if (repo is DbRepository<T>)
                {
                    return (DbRepository<T>)repo;
                }
            }
            return null;
        }

        public int Save()
        {
            Logger _logger = NLog.LogManager.GetCurrentClassLogger();
            List<LogEventInfo> logEventInfos = new List<LogEventInfo>();
            var modifiedEntries = _context.ChangeTracker.Entries();

            foreach(var entry in modifiedEntries)
            {
                switch(entry.State)
                {
                    case EntityState.Modified:
                        {
                            LogEventInfo eventInfo = new LogEventInfo { Level = NLog.LogLevel.Info };
                            var newItem = entry.Entity;
                            var oldItem = entry.GetDatabaseValues().ToObject();

                            eventInfo.Properties["NewValue"] = newItem;
                            eventInfo.Properties["OldValue"] = oldItem;

                            logEventInfos.Add(eventInfo);

                            break;
                        }

                    case EntityState.Deleted:
                        {
                            LogEventInfo eventInfo = new LogEventInfo { Level = NLog.LogLevel.Info };
                            var deletedItem = entry.Entity;

                            eventInfo.Properties["DeletedItem"] = deletedItem;

                            logEventInfos.Add(eventInfo);

                            break;
                        }

                    case EntityState.Added:
                        {
                            LogEventInfo eventInfo = new LogEventInfo { Level = NLog.LogLevel.Info };
                            var addedItem = entry.Entity;

                            eventInfo.Properties["AddedItem"] = addedItem;

                            logEventInfos.Add(eventInfo);

                            break;
                        }
                }
            }

            int changesCount = _context.SaveChanges();

            foreach(LogEventInfo logEvent in logEventInfos)
            {
                _logger.Log(logEvent);
            }

            return changesCount;
        }

        private bool _disposed = false;

        private void Dispose(bool disposing)
        {
            if(!_disposed && disposing)
            {
                _repos.Clear();
                _context.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

    }
}
