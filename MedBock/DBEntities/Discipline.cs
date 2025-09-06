using System;
using System.Collections.Generic;

namespace MedBock.DBEntities;

public partial class Discipline
{
    public int DisciplineId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<DoctorDiscipline> DoctorDisciplines { get; set; } = new List<DoctorDiscipline>();
}
