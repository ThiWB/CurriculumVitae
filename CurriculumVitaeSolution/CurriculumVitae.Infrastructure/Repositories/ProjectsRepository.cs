using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurriculumVitae.Core.Domain.Entities;
using CurriculumVitae.Core.Domain.RepositoryContracts;
using CurriculumVitae.Infrastructure.Data;
using Dapper;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace CurriculumVitae.Infrastructure.Repositories
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ProjectsRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(Project project)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                INSERT INTO Projects
                (
                    ProjectName,
                    Subtitle,
                    Description,
                    Image,
                    Link,
                    DisplayOrder
                )
                OUTPUT INSERTED.Id
                VALUES
                (
                    @ProjectName,
                    @Subtitle,
                    @Description,
                    @Image,
                    @Link,
                    @DisplayOrder
                );
                """;

            project.Id = await connection.ExecuteScalarAsync<int>(sql, project);
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                DELETE FROM Projects
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    ProjectName,
                    Subtitle,
                    Description,
                    Image,          
                    Link,
                    DisplayOrder
                FROM Projects
                ORDER BY Id DESC;
                """;

            return await connection.QueryAsync<Project>(sql);
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    ProjectName,
                    Subtitle,
                    Description,
                    Image,          
                    Link,
                    DisplayOrder
                FROM Projects
                WHERE Id = @Id;
                """;

            return await connection.QueryFirstOrDefaultAsync<Project>(sql, new { Id = id });
        }

        public async Task UpdateAsync(Project project)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                UPDATE Projects
                SET
                    ProjectName = @ProjectName,
                    Subtitle = @Subtitle,
                    Description = @Description,
                    Image = @Image,
                    Link = @Link,
                    DisplayOrder = @DisplayOrder
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, project);
        }
    }
}
