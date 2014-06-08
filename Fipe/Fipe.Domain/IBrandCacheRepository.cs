using System.Collections.Generic;

namespace Fipe.Domain
{
    public interface IBrandCacheRepository
    {
        void Save(Brand brand);

        IEnumerable<Brand> GetAllBrands();

        bool Exists(int id, string name);

        void Delete(Brand brand);
    }
}
