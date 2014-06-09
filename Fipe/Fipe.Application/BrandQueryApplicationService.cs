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
        private readonly ITypeAdapterFactory _adapterFactory;

        public BrandQueryApplicationService(IBrandCacheRepository cacheRepository, ITypeAdapterFactory adapterFactory)
        {
            _adapterFactory = adapterFactory;
            _cacheRepository = cacheRepository;
        }

        public IEnumerable<BrandViewModel> GetAllBrands()
        {
            var allBrands = _cacheRepository.GetAllBrands();

            return allBrands.ProjectedAs<List<BrandViewModel>>(_adapterFactory);
        }
    }
}
