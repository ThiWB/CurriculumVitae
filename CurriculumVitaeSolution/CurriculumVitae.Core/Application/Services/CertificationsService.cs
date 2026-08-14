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
    public class CertificationsService : ICertificationsService
    {
        private readonly ICertificationsRepository _certificationsRepository;

        public CertificationsService(ICertificationsRepository certificationsRepository)
        {
            _certificationsRepository = certificationsRepository;
        }

        public async Task<CertificationDTO> CreateAsync(CertificationDTO certification)
        {
            var certificationEntity = new Certification
            {
                CertificationName = certification.CertificationName,
                Issuer = certification.Issuer,
                Workload = certification.Workload,
                Contents = certification.Contents,
                Link = certification.Link,
                DisplayOrder = certification.DisplayOrder
            };

            await _certificationsRepository.AddAsync(certificationEntity);

            certification.Id = certificationEntity.Id;

            return certification;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var certificationEntity = await _certificationsRepository.GetByIdAsync(id);

            if (certificationEntity == null)
            {
                return false;
            }

            await _certificationsRepository.DeleteAsync(id);

            return true;
        }

        public async Task<IEnumerable<CertificationDTO>> GetAllAsync()
        {
            var certificationsEntities = await _certificationsRepository.GetAllAsync();

            return certificationsEntities.Select(certificationsEntities => new CertificationDTO
            {
                Id = certificationsEntities.Id,
                CertificationName = certificationsEntities.CertificationName,
                Issuer = certificationsEntities.Issuer,
                Workload = certificationsEntities.Workload,
                Contents = certificationsEntities.Contents,
                Link = certificationsEntities.Link,
                DisplayOrder = certificationsEntities.DisplayOrder
            });
        }

        public async Task<CertificationDTO?> GetByIdAsync(int id)
        {
            var certificationEntity = await _certificationsRepository.GetByIdAsync(id);

            if (certificationEntity == null)
            {
                return null;
            }

            return new CertificationDTO
            {
                CertificationName = certificationEntity.CertificationName,
                Issuer = certificationEntity.Issuer,
                Workload = certificationEntity.Workload,
                Contents = certificationEntity.Contents,
                Link = certificationEntity.Link,
                DisplayOrder = certificationEntity.DisplayOrder
            };
        }

        public async Task<bool> UpdateAsync(int id, CertificationDTO certification)
        {
            var existingCertification = await _certificationsRepository.GetByIdAsync(id);

            if (existingCertification == null)
            {
                return false;
            }

            existingCertification.CertificationName = certification.CertificationName;
            existingCertification.Issuer = certification.Issuer;
            existingCertification.Workload = certification.Workload;
            existingCertification.Contents = certification.Contents;
            existingCertification.Link = certification.Link;
            existingCertification.DisplayOrder = certification.DisplayOrder;

            await _certificationsRepository.UpdateAsync(existingCertification);

            return true;
        }
    }
}
