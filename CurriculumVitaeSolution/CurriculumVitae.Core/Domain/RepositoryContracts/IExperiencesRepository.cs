using CurriculumVitae.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurriculumVitae.Core.Domain.RepositoryContracts
{
    public interface IExperiencesRepository
    {
        Task<IEnumerable<Experience>> GetAllAsync();

        Task<Experience?> GetByIdAsync(int id);

        Task AddAsync(Experience experience);

        Task UpdateAsync(Experience experience);

        Task DeleteAsync(int id);
    }
}
