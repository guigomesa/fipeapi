using System;
using System.Configuration;
using System.Data.Entity.Infrastructure;

namespace Fipe.Repository.EntityFramework
{
    public class FipeDbContextFactory : IDbContextFactory<FipeDbContext>
    {
        public FipeDbContext Create()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Fipe"];
            if (connectionString == null)
                throw new NullReferenceException("No connection string found with the name: Fipe");

            return new FipeDbContext(connectionString.ConnectionString);
        }
    }
}