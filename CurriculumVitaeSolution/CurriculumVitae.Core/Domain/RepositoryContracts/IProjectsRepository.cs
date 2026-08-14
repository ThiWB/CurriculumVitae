using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurriculumVitae.Core.Domain.Entities;

namespace CurriculumVitae.Core.Domain.RepositoryContracts
{
    public interface IProjectsRepository
    {
        Task<IEnumerable<Project>> GetAllAsync();

        Task<Project?> GetByIdAsync(int id);

        Task AddAsync(Project project);

        Task UpdateAsync(Project project);

        Task DeleteAsync(int id);
    }
}
