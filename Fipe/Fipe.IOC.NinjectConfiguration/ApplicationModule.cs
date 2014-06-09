using System.Data.Entity;
using Fipe.Application;
using Fipe.Application.Contracts;
using Fipe.Crawler;
using Fipe.Domain;
using Fipe.Infrastructure.Adapter;
using Fipe.Infrastructure.Adapter.AutoMapper;
using Fipe.Repository.EntityFramework;
using Fipe.Repository.EntityFramework.DbContextManagement;
using Ninject.Modules;

namespace Fipe.IOC.NinjectConfiguration
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>()
                .ToMethod(x => FipeDbContextManager.GetCurrentContext())
                .OnDeactivation(x => FipeDbContextManager.CloseDbContext());

            Bind<ITypeAdapterFactory>().To<AutoMapperTypeAdapterFactory>();

            Bind<IUnitOfWorkFactory>().To<UnitOfWorkFactory>();
            Bind<IBrandCacheRepository>().To<BrandCacheRepository>();

            Bind<IBrandCrawler>().To<BrandCrawler>();

            Bind<IBrandCrawlerApplicationService>().To<BrandCrawlerApplicationService>();
            Bind<IBrandQueryApplicationService>().To<BrandQueryApplicationService>();
        }
    }
}
