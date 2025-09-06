using System;
using System.Collections.Generic;

namespace MedBock.DBEntities;

public partial class DoctorSchedule
{
    public int DoctorScheduleId { get; set; }

    public int PersonId { get; set; }

    public byte WeekDay { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public virtual Doctore Person { get; set; } = null!;
}
