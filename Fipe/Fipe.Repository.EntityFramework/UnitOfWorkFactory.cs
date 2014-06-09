using System.Data.Entity;
using Fipe.Domain;

namespace Fipe.Repository.EntityFramework
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly DbContext _context;

        public UnitOfWorkFactory(DbContext context)
        {
            _context = context;
        }

        public IUnityOfWork Build()
        {
            return new UnitOfWork(_context);
        }
    }
}