using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MP.APICOMPRAS.Domain.Entities;

namespace MP.APICOMPRAS.Infra.Data.Context
{
    public class APICOMPRASDbContext : DbContext
    {

        public APICOMPRASDbContext(DbContextOptions<APICOMPRASDbContext> options) : base(options)
        {

        }

        public APICOMPRASDbContext()
        { }

        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(APICOMPRASDbContext).Assembly);
        }
    }
}