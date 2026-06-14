using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class CustomerHistoryDTO
    {
        public int AppointmentId { get; set; }
        public int StaffId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }

        public string ServiceName { get; set; }
        public decimal ActualPrice { get; set; }
    }
}
