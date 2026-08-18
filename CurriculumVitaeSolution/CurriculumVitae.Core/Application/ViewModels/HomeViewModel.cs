using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurriculumVitae.Core.Application.DTOs;

namespace CurriculumVitae.Core.Application.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<ProjectDTO> Projects { get; set; } = [];
        public IEnumerable<ExperienceDTO> Experiences { get; set; } = [];
        public IEnumerable<CertificationDTO> Certifications { get; set; } = [];
    }
}
