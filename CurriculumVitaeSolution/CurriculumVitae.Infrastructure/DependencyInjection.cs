using CurriculumVitae.Core.Domain.RepositoryContracts;
using CurriculumVitae.Infrastructure.Data;
using CurriculumVitae.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CurriculumVitae.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

            services.AddScoped<IProjectsRepository, ProjectsRepository>();
            services.AddScoped<IExperiencesRepository, ExperiencesRepository>();
            services.AddScoped<ICertificationsRepository, CertificationsRepository>();

            return services;
        }
    }
}