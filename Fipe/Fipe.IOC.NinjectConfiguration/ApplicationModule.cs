using Fipe.Application;
using Fipe.Application.Contracts;
using Fipe.Crawler;
using Fipe.Domain;
using Fipe.Infrastructure.Adapter;
using Fipe.Infrastructure.Adapter.AutoMapper;
using Ninject.Modules;

namespace Fipe.IOC.NinjectConfiguration
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITypeAdapterFactory>().To<AutoMapperTypeAdapterFactory>();

            Bind<IBrandCrawler>().To<BrandCrawler>();

            Bind<IBrandCrawlerApplicationService>().To<BrandCrawlerApplicationService>();
            Bind<IBrandQueryApplicationService>().To<BrandQueryApplicationService>();
        }
    }
}
