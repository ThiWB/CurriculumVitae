using CurriculumVitae.Core.Application.DTOs;
using CurriculumVitae.Core.Application.ServiceContracts;
using CurriculumVitae.Core.Domain.Entities;
using CurriculumVitae.Core.Domain.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurriculumVitae.Core.Application.Services
{
    public class ExperiencesService : IExperiencesService
    {
        private readonly IExperiencesRepository _experiencesRepository;

        public ExperiencesService(IExperiencesRepository experiencesRepository)
        {
            _experiencesRepository = experiencesRepository;
        }

        public async Task<ExperienceDTO> CreateAsync(ExperienceDTO experience)
        {
            var experienceEntity = new Experience
            {
                CompanyName = experience.CompanyName,
                Subtitle = experience.Subtitle,
                EntryDate = experience.EntryDate,
                EndDate = experience.EndDate,
                Description = experience.Description,
                DisplayOrder = experience.DisplayOrder
            };

            await _experiencesRepository.AddAsync(experienceEntity);

            experience.Id = experienceEntity.Id;

            return experience;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var experienceEntity = await _experiencesRepository.GetByIdAsync(id);

            if (experienceEntity == null)
            {
                return false;
            }

            await _experiencesRepository.DeleteAsync(id);

            return true;
        }

        public async Task<IEnumerable<ExperienceDTO>> GetAllAsync()
        {
            var experiencesEntities = await _experiencesRepository.GetAllAsync();

            return experiencesEntities.Select(experiencesEntities => new ExperienceDTO
            {
                Id = experiencesEntities.Id,
                CompanyName = experiencesEntities.CompanyName,
                Subtitle = experiencesEntities.Subtitle,
                EntryDate = experiencesEntities.EntryDate,
                EndDate = experiencesEntities.EndDate,
                Description = experiencesEntities.Description,
                DisplayOrder = experiencesEntities.DisplayOrder
            });
        }

        public async Task<ExperienceDTO?> GetByIdAsync(int id)
        {
            var experienceEntity = await _experiencesRepository.GetByIdAsync(id);

            if (experienceEntity == null)
            {
                return null;
            }

            return new ExperienceDTO
            {
                CompanyName = experienceEntity.CompanyName,
                Subtitle = experienceEntity.Subtitle,
                EntryDate = experienceEntity.EntryDate,
                EndDate = experienceEntity.EndDate,
                Description = experienceEntity.Description,
                DisplayOrder = experienceEntity.DisplayOrder
            };
        }

        public async Task<bool> UpdateAsync(int id, ExperienceDTO experience)
        {
            var existingExperience = await _experiencesRepository.GetByIdAsync(id);

            if (existingExperience == null)
            {
                return false;
            }

            existingExperience.CompanyName = experience.CompanyName;
            existingExperience.Subtitle = experience.Subtitle;
            existingExperience.EntryDate = experience.EntryDate;
            existingExperience.EndDate = experience.EndDate;
            existingExperience.Description = experience.Description;
            existingExperience.DisplayOrder = experience.DisplayOrder;

            await _experiencesRepository.UpdateAsync(existingExperience);

            return true;
        }
    }
}
