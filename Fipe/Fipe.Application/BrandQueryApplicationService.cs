using System.Collections.Generic;
using Fipe.Application.Contracts;
using Fipe.Application.ViewModels;
using Fipe.Domain;
using Fipe.Infrastructure.Adapter;

namespace Fipe.Application
{
    public class BrandQueryApplicationService : IBrandQueryApplicationService
    {
        private readonly IBrandCacheRepository _cacheRepository;
        private readonly IBrandCrawler _crawler;
        private readonly ITypeAdapterFactory _adapterFactory;

        public BrandQueryApplicationService(IBrandCrawler crawler, ITypeAdapterFactory adapterFactory)
        {
            _adapterFactory = adapterFactory;
            _crawler = crawler;
        }

        public IEnumerable<BrandViewModel> GetAllBrands()
        {
            var allBrands = _crawler.FindAllBrands();

            return allBrands.ProjectedAs<List<BrandViewModel>>(_adapterFactory);
        }
    }
}
