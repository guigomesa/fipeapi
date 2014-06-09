using System.Data.Entity.Infrastructure;
using System.Web;

namespace Fipe.Repository.EntityFramework.DbContextManagement
{
    public static class FipeDbContextManager
    {
        private const string FipePerRequestDbContext = "FPRDBCM";

        private static readonly IDbContextFactory<FipeDbContext> Factory = new FipeDbContextFactory();

        public static void BuildDbContext()
        {
            var dbContext = Factory.Create();

            if (!HttpContext.Current.Items.Contains(FipePerRequestDbContext))
                HttpContext.Current.Items.Add(FipePerRequestDbContext, dbContext);
        }

        public static FipeDbContext GetCurrentContext()
        {
            return HttpContext.Current.Items[FipePerRequestDbContext] as FipeDbContext;
        }

        public static void CloseDbContext()
        {
            var currentContext = GetCurrentContext();
            if (currentContext == null) return;

            currentContext.Dispose();
            HttpContext.Current.Items.Remove(FipePerRequestDbContext);
        }
    }
}