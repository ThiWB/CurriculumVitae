using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurriculumVitae.Core.Domain.RepositoryContracts;
using CurriculumVitae.Infrastructure.Data;
using CurriculumVitae.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CurriculumVitae.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            services.AddScoped<IProjectsRepository, ProjectsRepository>();
            services.AddScoped<IExperiencesRepository, ExperiencesRepository>();
            services.AddScoped<ICertificationsRepository, CertificationsRepository>();

            return services;

        }
    }
}
