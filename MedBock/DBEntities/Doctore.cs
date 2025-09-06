using System;
using System.Collections.Generic;

namespace MedBock.DBEntities;

public partial class Doctore
{
    public int PersonId { get; set; }

    public string Specialty { get; set; } = null!;

    public string LicenseNumber { get; set; } = null!;

    public string WorkHours { get; set; } = null!;

    public byte[] LicenseFile { get; set; } = null!;

    public string Bio { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<DoctorDiscipline> DoctorDisciplines { get; set; } = new List<DoctorDiscipline>();

    public virtual ICollection<DoctorSchedule> DoctorSchedules { get; set; } = new List<DoctorSchedule>();

    public virtual Person Person { get; set; } = null!;
}
