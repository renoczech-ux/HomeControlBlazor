using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblUser
{
    public int UsrId { get; set; }

    public string UsrUsername { get; set; } = null!;

    public string? UsrPassword { get; set; }

    public string? UsrPhoneNr { get; set; }

    public string? UsrEmail { get; set; }

    public int? UsrPin { get; set; }

    public int? UsrActiveAccount { get; set; }
}
