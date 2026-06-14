using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class PaymentDTO
    {
        public int Id { get; set; }

        [Required]
        public int AppointmentId { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        public DateTime PaymentDate { get; set; }

        [Required]
        public string PaymentMethod { get; set; } = null!;

        [Required]
        public string Status { get; set; } = null!;
    }
}