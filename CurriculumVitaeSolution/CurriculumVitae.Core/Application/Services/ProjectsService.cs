using CurriculumVitae.Core.Application.DTOs;
using CurriculumVitae.Core.Application.ServiceContracts;
using CurriculumVitae.Core.Domain.RepositoryContracts;
using CurriculumVitae.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel;

namespace CurriculumVitae.Core.Application.Services
{

   public class ProjectsService : IProjectsService
   {
        private readonly IProjectsRepository _projectsRepository;

        public ProjectsService(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public async Task<ProjectDTO> CreateAsync(ProjectDTO project)
        {
            var projectEntity = new Project
            {
                ProjectName = project.ProjectName,
                Subtitle = project.Subtitle,
                Description = project.Description,
                Image = project.Image,
                Link = project.Link,
                DisplayOrder = project.DisplayOrder
            };

            await _projectsRepository.AddAsync(projectEntity);

            project.Id = projectEntity.Id;

            return project;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var projectEntity = await _projectsRepository.GetByIdAsync(id);

            if(projectEntity == null)
            {
                return false;
            }

            await _projectsRepository.DeleteAsync(id);

            return true;
        }

        public async Task<IEnumerable<ProjectDTO>> GetAllAsync()
        {
            var projectsEntities = await _projectsRepository.GetAllAsync();

            return projectsEntities.Select(projectsEntities => new ProjectDTO
            {
                Id = projectsEntities.Id,
                ProjectName = projectsEntities.ProjectName,
                Subtitle = projectsEntities.Subtitle,
                Description = projectsEntities.Description,
                Image = projectsEntities.Image,
                Link = projectsEntities.Link,
                DisplayOrder = projectsEntities.DisplayOrder
            });
        }

        public async Task<ProjectDTO?> GetByIdAsync(int id)
        {
            var projectEntity = await _projectsRepository.GetByIdAsync(id);

            if(projectEntity == null)
            {
                return null;
            }

            return new ProjectDTO
            {
                ProjectName = projectEntity.ProjectName,
                Subtitle = projectEntity.Subtitle,
                Description = projectEntity.Description,
                Image = projectEntity.Image,
                Link = projectEntity.Link,
                DisplayOrder = projectEntity.DisplayOrder
            };
        }

        public async Task<bool> UpdateAsync(int id, ProjectDTO project)
        {
            var existingProject = await _projectsRepository.GetByIdAsync(id);

            if(existingProject == null)
            {
                return false;
            }

            existingProject.ProjectName = project.ProjectName;
            existingProject.Subtitle = project.Subtitle;
            existingProject.Description = project.Description;
            existingProject.Image = project.Image;
            existingProject.Link = project.Link;
            existingProject.DisplayOrder = project.DisplayOrder;

            await _projectsRepository.UpdateAsync(existingProject);

            return true;
        }
    }
}
