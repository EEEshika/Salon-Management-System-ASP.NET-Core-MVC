using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class StaffDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Phone { get; set; } = null!;

        public string? Specialty { get; set; }

        public int? ExperienceYears { get; set; }
    }
}
