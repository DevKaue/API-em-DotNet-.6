using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MP.APICOMPRAS.Infra.Data.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<APICOMPRASDbContext>
    {
        public APICOMPRASDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<APICOMPRASDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER01;Database=apicompras;Trusted_Connection=True;");

            return new APICOMPRASDbContext(optionsBuilder.Options);
        }
    }
}