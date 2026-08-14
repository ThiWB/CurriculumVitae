using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurriculumVitae.Core.Application.DTOs;

namespace CurriculumVitae.Core.Application.ServiceContracts
{
    public interface ICertificationsService
    {
        Task<IEnumerable<CertificationDTO>> GetAllAsync();

        Task<CertificationDTO?> GetByIdAsync(int id);

        Task<CertificationDTO> CreateAsync(CertificationDTO certification);

        Task<bool> UpdateAsync(int id, CertificationDTO certification);

        Task<bool> DeleteAsync(int id);
    }
}
