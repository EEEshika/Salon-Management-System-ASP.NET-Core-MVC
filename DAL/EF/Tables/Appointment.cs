using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Appointment
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int StaffId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string Status { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual ICollection<AppointmentService> AppointmentServices { get; set; } = new List<AppointmentService>();

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Staff Staff { get; set; } = null!;
}
