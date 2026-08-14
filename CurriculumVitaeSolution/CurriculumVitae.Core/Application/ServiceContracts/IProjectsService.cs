using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurriculumVitae.Core.Application.DTOs;

namespace CurriculumVitae.Core.Application.ServiceContracts
{
    public interface IProjectsService
    {
        Task<IEnumerable<ProjectDTO>> GetAllAsync();

        Task<ProjectDTO?> GetByIdAsync(int id);

        Task<ProjectDTO> CreateAsync(ProjectDTO project);

        Task<bool> UpdateAsync(int id, ProjectDTO project);

        Task<bool> DeleteAsync(int id);
    }
}
