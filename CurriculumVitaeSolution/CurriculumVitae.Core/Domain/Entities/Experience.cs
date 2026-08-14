using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurriculumVitae.Core.Domain.Entities
{
    public class Experience
    {
        public int Id { get; set; }

        public string? CompanyName { get; set; }

        public string? Subtitle { get; set; }

        public DateOnly EntryDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public string? Description { get; set; }

        public int DisplayOrder { get; set; }
    }
}
