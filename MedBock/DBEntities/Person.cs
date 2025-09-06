using System;
using System.Collections.Generic;

namespace MedBock.DBEntities;

public partial class Person
{
    public int PersonId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PasswordHash { get; set; }

    public bool Gender { get; set; }

    public string Role { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Doctore? Doctore { get; set; }

    public virtual Patient? Patient { get; set; }
}
