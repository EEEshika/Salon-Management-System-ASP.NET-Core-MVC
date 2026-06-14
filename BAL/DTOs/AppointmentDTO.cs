using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int StaffId { get; set; }


        [Required]
        public int ServiceId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public string Status { get; set; } = null!;

        public string? Notes { get; set; }

        public string? CustomerName { get; set; }
        public string? StaffName { get; set; }
        public string? ServiceName { get; set; }


    }
}