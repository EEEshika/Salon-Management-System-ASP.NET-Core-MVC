using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class StaffAppointmentDTO
    {
        public int AppointmentId { get; set; }
        public string CustomerName { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
    }
}