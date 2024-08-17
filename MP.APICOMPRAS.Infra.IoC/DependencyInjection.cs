using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MP.APICOMPRAS.Application.Mappings;
using MP.APICOMPRAS.Application.Services;
using MP.APICOMPRAS.Application.Services.Interfaces;
using MP.APICOMPRAS.Domain.Repositories;
using MP.APICOMPRAS.Infra.Data.Context;
using MP.APICOMPRAS.Infra.Data.Repositories;

namespace MP.APICOMPRAS.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<APICOMPRASDbContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("")));
            services.AddScoped<IPersonRepository, PersonRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<IPersonService, PersonService>();
            return services;
        }
    }
}