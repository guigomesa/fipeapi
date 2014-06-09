using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Fipe.Domain;

namespace Fipe.Repository.EntityFramework
{
    public class BrandCacheRepository : IBrandCacheRepository
    {
        private readonly DbContext _context;

        public BrandCacheRepository(DbContext context)
        {
            _context = context;
        }

        public void Save(Brand brand)
        {
            _context.Set<Brand>().AddOrUpdate(brand);
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            return _context.Set<Brand>().ToList();
        }

        public bool Exists(int id, string name)
        {
            return _context.Set<Brand>().Any(brand => brand.Id == id && brand.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void Delete(Brand brand)
        {
            _context.Set<Brand>().Remove(brand);
        }
    }
}
