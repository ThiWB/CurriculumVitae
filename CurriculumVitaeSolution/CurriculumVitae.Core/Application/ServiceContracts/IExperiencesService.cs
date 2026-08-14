using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurriculumVitae.Core.Application.DTOs;

namespace CurriculumVitae.Core.Application.ServiceContracts
{
    public interface IExperiencesService
    {
        Task<IEnumerable<ExperienceDTO>> GetAllAsync();

        Task<ExperienceDTO?> GetByIdAsync(int id);

        Task<ExperienceDTO> CreateAsync(ExperienceDTO experience);

        Task<bool> UpdateAsync(int id, ExperienceDTO experience);

        Task<bool> DeleteAsync(int id);
    }
}
