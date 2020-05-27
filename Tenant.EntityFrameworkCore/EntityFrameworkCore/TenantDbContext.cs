using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant.EntityFrameworkCore
{
    public class TenantDbContext : DbContext
    {     
        public TenantDbContext(DbContextOptions<TenantDbContext> options)
          : base(options)
        {

        }

        public DbSet<TenantPersonnel> TenantPersonnels { get; set; }
        public DbSet<Gender> Genders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData(new Gender[] {
                new Gender{Name="Male",Id=1},
                new Gender{Name="Female",Id=2},
            });
        }
    }
}
