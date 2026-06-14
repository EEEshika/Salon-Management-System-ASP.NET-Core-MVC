using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Payment
{
    public int Id { get; set; }

    public int AppointmentId { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime PaymentDate { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual Appointment Appointment { get; set; } = null!;
}
