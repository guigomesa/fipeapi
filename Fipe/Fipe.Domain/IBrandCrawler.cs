using System.Collections.Generic;

namespace Fipe.Domain
{
    public interface IBrandCrawler
    {
        IEnumerable<Brand> FindAllBrands();
    }
}
