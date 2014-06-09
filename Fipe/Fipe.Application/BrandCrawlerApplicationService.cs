using System.Collections.Generic;
using System.Linq;
using Fipe.Application.Contracts;
using Fipe.Domain;

namespace Fipe.Application
{
    public class BrandCrawlerApplicationService : IBrandCrawlerApplicationService
    {
        private readonly IBrandCrawler _crawler;

        private readonly IBrandCacheRepository _cacheRepository;

        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public BrandCrawlerApplicationService(IBrandCrawler crawler, IBrandCacheRepository cacheRepository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _crawler = crawler;
            _cacheRepository = cacheRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void CrawlAndUpdateCacheRepository()
        {
            var crawledbrands = _crawler.FindAllBrands().ToList();

            using (var uow = _unitOfWorkFactory.Build())
            {
                VerifyAndRemoveOldBrandsFromRepository(crawledbrands);

                SaveCrawledBrandsToRepository(crawledbrands);

                uow.Commit();
            }
        }

        private void SaveCrawledBrandsToRepository(IEnumerable<Brand> crawledBrands)
        {
            foreach (var crawledbrand in crawledBrands)
                _cacheRepository.Save(crawledbrand);
        }

        private void VerifyAndRemoveOldBrandsFromRepository(ICollection<Brand> crawledBrands)
        {
            var brandsInDb = _cacheRepository.GetAllBrands();

            foreach (var brand in brandsInDb.Where(brand => !crawledBrands.Contains(brand)))
                _cacheRepository.Delete(brand);
        }
    }
}
