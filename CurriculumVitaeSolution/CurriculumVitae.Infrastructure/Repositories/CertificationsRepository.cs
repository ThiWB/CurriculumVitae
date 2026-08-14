using CurriculumVitae.Core.Domain.Entities;
using CurriculumVitae.Core.Domain.RepositoryContracts;
using CurriculumVitae.Infrastructure.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurriculumVitae.Infrastructure.Repositories
{
    public class CertificationsRepository : ICertificationsRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public CertificationsRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(Certification certification)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                INSERT INTO Certifications
                (
                    CertificationName,
                    Issuer,
                    Workload,
                    Contents,
                    Link,
                    DisplayOrder
                )
                OUTPUT INSERTED.Id
                VALUES
                (
                    @CertificationName,
                    @Issuer,
                    @Workload,
                    @Contents,
                    @Link,
                    @DisplayOrder
                );
                """;

            certification.Id = await connection.ExecuteScalarAsync<int>(sql, certification);
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                DELETE FROM Certifications
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Certification>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    CertificationName,
                    Issuer,
                    Workload,
                    Contents,          
                    Link,
                    DisplayOrder
                FROM Certifications
                ORDER BY Id DESC;
                """;

            return await connection.QueryAsync<Certification>(sql);
        }

        public async Task<Certification?> GetByIdAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    CertificationName,
                    Issuer,
                    Workload,
                    Contents,          
                    Link,
                    DisplayOrder
                FROM Certifications
                WHERE Id = @Id;
                """;

            return await connection.QueryFirstOrDefaultAsync<Certification>(sql, new { Id = id });
        }

        public async Task UpdateAsync(Certification certification)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                UPDATE Certifications
                SET
                    CertificationName = @CertificationName,
                    Issuer = @Issuer,
                    Workload = @Workload,
                    Contents = @Contents,
                    Link = @Link,
                    DisplayOrder = @DisplayOrder
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, certification);
        }
    }
}
