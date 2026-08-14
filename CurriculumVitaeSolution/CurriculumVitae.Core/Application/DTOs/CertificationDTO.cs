using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurriculumVitae.Core.Application.DTOs
{
    public class CertificationDTO
    {
        public int Id { get; set; }

        public string? CertificationName { get; set; }

        public string? Issuer { get; set; }

        public int Workload { get; set; }

        public string? Contents { get; set; }

        public string? Link { get; set; }

        public int DisplayOrder { get; set; }
    }
}
