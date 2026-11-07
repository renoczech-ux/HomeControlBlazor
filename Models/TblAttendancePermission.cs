using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblAttendancePermission
{
    public int AtpId { get; set; }

    public string AtpRfidnr { get; set; } = null!;

    public int AtpDoorNr { get; set; }
}
