using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurriculumVitae.Core.Application.DTOs
{
    public class ProjectDTO
    {
        public int Id { get; set; }

        public string? ProjectName { get; set; }

        public string? Subtitle { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public string? Link { get; set; }

        public int DisplayOrder { get; set; }
    }
}
