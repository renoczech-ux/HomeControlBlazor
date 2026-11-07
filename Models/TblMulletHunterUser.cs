using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblMulletHunterUser
{
    public int MluId { get; set; }

    public string MluUsername { get; set; } = null!;

    public string? MluEmail { get; set; }

    public string MluPassword { get; set; } = null!;

    public DateTime MluDateTime { get; set; }
}
