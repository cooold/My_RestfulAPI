using System;
using System.Collections.Generic;

namespace firstAPI_2023_04_19.Models;

public partial class Staff
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Department { get; set; }

    public int? Salary { get; set; }

    public virtual ICollection<InfoMessage>? InfoMessages { get; set; } = new List<InfoMessage>();
}
