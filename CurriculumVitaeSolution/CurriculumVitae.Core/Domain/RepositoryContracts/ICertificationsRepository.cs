using CurriculumVitae.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurriculumVitae.Core.Domain.RepositoryContracts
{
    public interface ICertificationsRepository
    {
        Task<IEnumerable<Certification>> GetAllAsync();

        Task<Certification?> GetByIdAsync(int id);

        Task AddAsync(Certification certification);

        Task UpdateAsync(Certification certification);

        Task DeleteAsync(int id);
    }
}
