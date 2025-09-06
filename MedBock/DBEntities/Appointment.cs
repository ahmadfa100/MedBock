using System;
using System.Collections.Generic;

namespace MedBock.DBEntities;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int DoctorId { get; set; }

    public int PatientId { get; set; }

    public int DisciplineId { get; set; }

    public DateTime StartAt { get; set; }

    public DateTime EndAt { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Discipline Discipline { get; set; } = null!;

    public virtual Doctore Doctor { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
