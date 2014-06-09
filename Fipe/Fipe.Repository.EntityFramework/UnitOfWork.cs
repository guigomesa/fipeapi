using System;
using System.Data.Entity;
using Fipe.Domain;

namespace Fipe.Repository.EntityFramework
{
    public class UnitOfWork : IUnityOfWork
    {
        private readonly DbContext _context;

        private bool _disposed;

        public UnitOfWork(DbContext dbContext)
        {
            _context = dbContext;
        }

        public void Commit()
        {
            if (_context != null)
                _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                _context.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
