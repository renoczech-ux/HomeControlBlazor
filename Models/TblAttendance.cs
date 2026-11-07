using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblAttendance
{
    public int AtrId { get; set; }

    public string AtrRfidnr { get; set; } = null!;

    public int AtrDoorNr { get; set; }

    public DateTime AtrDate { get; set; }

    public TimeSpan AtrTime { get; set; }
}
