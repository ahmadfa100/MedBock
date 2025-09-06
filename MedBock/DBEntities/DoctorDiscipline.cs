using System;
using System.Collections.Generic;

namespace MedBock.DBEntities;

public partial class DoctorDiscipline
{
    public int DoctorDisciplineId { get; set; }

    public int DoctorId { get; set; }

    public int DisciplineId { get; set; }

    public virtual Discipline Discipline { get; set; } = null!;

    public virtual Doctore Doctor { get; set; } = null!;
}
