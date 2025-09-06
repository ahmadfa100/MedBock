using System;
using System.Collections.Generic;

namespace MedBock.DBEntities;

public partial class Patient
{
    public int PersonId { get; set; }

    public bool HasHealthInsurance { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Person Person { get; set; } = null!;
}
