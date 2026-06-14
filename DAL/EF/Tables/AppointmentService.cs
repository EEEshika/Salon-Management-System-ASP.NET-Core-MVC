using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class AppointmentService
{
    public int Id { get; set; }

    public int AppointmentId { get; set; }

    public int ServiceId { get; set; }

    public decimal Price { get; set; }

    public virtual Appointment Appointment { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
