using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurriculumVitae.Core.Domain.Entities;
using CurriculumVitae.Core.Domain.RepositoryContracts;
using CurriculumVitae.Infrastructure.Data;
using Dapper;

namespace CurriculumVitae.Infrastructure.Repositories
{
    public class ExperiencesRepository : IExperiencesRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ExperiencesRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(Experience experience)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                INSERT INTO Experiences
                (
                    CompanyName,
                    Subtitle,
                    EntryDate,
                    EndDate,
                    Description,
                    DisplayOrder
                )
                OUTPUT INSERTED.Id
                VALUES
                (
                    @CompanyName,
                    @Subtitle,
                    @EntryDate,
                    @EndDate,
                    @Description,
                    @DisplayOrder
                );
                """;

            experience.Id = await connection.ExecuteScalarAsync<int>(sql, experience);
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                DELETE FROM Experiences
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Experience>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    CompanyName,
                    Subtitle,
                    EntryDate,
                    EndDate,          
                    Description,
                    DisplayOrder
                FROM Experiences
                ORDER BY Id DESC;
                """;

            return await connection.QueryAsync<Experience>(sql);
        }

        public async Task<Experience?> GetByIdAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    CompanyName,
                    Subtitle,
                    EntryDate,
                    EndDate,          
                    Description,
                    DisplayOrder
                FROM Experiences
                WHERE Id = @Id;
                """;

            return await connection.QueryFirstOrDefaultAsync<Experience>(sql, new { Id = id });
        }

        public async Task UpdateAsync(Experience experience)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                UPDATE Experiences
                SET
                    CompanyName = @CompanyName,
                    Subtitle = @Subtitle,
                    EntryDate = @EntryDate,
                    EndDate = @EndDate,
                    Description = @Description,
                    DisplayOrder = @DisplayOrder
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, experience);
        }
    }
}
