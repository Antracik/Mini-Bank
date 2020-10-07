using Shared;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Data.Entities;
using Data.Queries;

namespace Data
{ 
    public class UnitOfWork : IDisposable
    { 
        private readonly BankContext _context;
        private readonly List<object> _repos = new List<object>();
        private readonly Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public UnitOfWork(BankContext context)
        {
            _context = context;
        }

        public BankContext BankContext { get {return _context; } }

        public UnitOfWork AddRepository<T>() where T : class, IBaseModel
        {
            DbRepository<T> repo = new DbRepository<T>(_context);
            _repos.Add(repo);
            return this;
        }

        public DbRepository<T> GetRepository<T>() where T : class, IBaseModel
        {
            foreach(object repo in _repos)
            {
                if (repo is DbRepository<T> repository)
                {
                    return repository;
                }
            }
            return null;
        }

        private List<LogEventInfo>  GetEntityChangesLogInfo()
        {
            List<LogEventInfo> logEventInfos = new List<LogEventInfo>();
            var modifiedEntries = _context.ChangeTracker.Entries();

            foreach (var entry in modifiedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        {
                            LogEventInfo eventInfo = new LogEventInfo { Level = NLog.LogLevel.Info };
                            var newItem = entry.Entity;
                            var oldItem = entry.GetDatabaseValues().ToObject();

                            eventInfo.Properties[Constants.mongoNewItemValues] = newItem;
                            eventInfo.Properties[Constants.mongoOldItemValues] = oldItem;

                            logEventInfos.Add(eventInfo);

                            break;
                        }

                    case EntityState.Deleted:
                        {
                            LogEventInfo eventInfo = new LogEventInfo { Level = NLog.LogLevel.Info };
                            var deletedItem = entry.Entity;

                            eventInfo.Properties[Constants.mongoDeletedItem] = deletedItem;

                            //logEventInfos.Add(eventInfo);

                            break;
                        }

                    case EntityState.Added:
                        {
                            LogEventInfo eventInfo = new LogEventInfo { Level = NLog.LogLevel.Info };
                            var addedItem = entry.Entity;

                            eventInfo.Properties[Constants.mongoAddedItem] = addedItem;

                            //logEventInfos.Add(eventInfo);

                            break;
                        }
                }
            }

            return logEventInfos;
        }

        public int Save()
        {
            var logEventInfos = GetEntityChangesLogInfo();

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
