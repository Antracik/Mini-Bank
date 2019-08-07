using Shared;
using System;
using System.Collections.Generic;


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
            return _context.SaveChanges();
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
