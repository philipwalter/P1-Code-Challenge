using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataProvider
{
    class ContextFactoryForMigrations : IDesignTimeDbContextFactory<P1DbContext>
    {

        private const string ConnectionString = "Server=localhost;Database=priority1;Trusted_Connection=True;";

        public P1DbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<P1DbContext>();
            optionsBuilder.UseSqlServer(ConnectionString,
                b => b.MigrationsAssembly("DataProvider"));

            return new P1DbContext(optionsBuilder.Options);
        }

    }
}
