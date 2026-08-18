using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurriculumVitae.Core.Application.DTOs
{
    public class ExperienceDTO
    {
        public int Id { get; set; }

        public string? CompanyName { get; set; }

        public string? Subtitle { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Description { get; set; }

        public int DisplayOrder { get; set; }
    }
}
