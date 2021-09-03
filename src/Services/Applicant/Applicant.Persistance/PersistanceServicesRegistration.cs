using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Applicant.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Applicant.Core.Contracts.Persistance;

namespace Applicant.Persistance
{
    public static class PersistanceServicesRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<TestRegistrationDbContext>(options => options.UseSqlServer
            (configuration.GetConnectionString("ServimotosDbConnection")));

            services.AddScoped(typeof(IAsyncRepository<>),typeof(BaseRepository<>));

            return services;
        }
    }
}
