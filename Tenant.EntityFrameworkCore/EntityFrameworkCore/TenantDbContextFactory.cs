using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Tenant.EntityFrameworkCore
{
    public class TenantDbContextFactory : IDesignTimeDbContextFactory<TenantDbContext>
    {
        public TenantDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TenantDbContext>();
            builder.UseSqlServer("Server=localhost;Database=TestDemoAstar;Trusted_Connection=True;MultipleActiveResultSets=true",
               optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(TenantDbContext).GetTypeInfo().Assembly.GetName().Name));
            return new TenantDbContext(builder.Options);
        }      
    }
}
