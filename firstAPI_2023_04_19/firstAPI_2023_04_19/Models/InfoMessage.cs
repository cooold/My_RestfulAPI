using System;
using System.Collections.Generic;

namespace firstAPI_2023_04_19.Models;

public partial class InfoMessage
{
    public int Id { get; set; }

    public int StaffId { get; set; }

    public string? Text { get; set; }

    public virtual Staff? Staff { get; set; } = null!;
}
