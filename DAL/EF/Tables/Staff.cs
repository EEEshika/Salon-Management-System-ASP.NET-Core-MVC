using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Staff
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Specialty { get; set; }

    public int? ExperienceYears { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual User? User { get; set; }
}
