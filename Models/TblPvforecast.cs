using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblPvforecast
{
    public int PvfId { get; set; }

    public DateTime PvfDate { get; set; }

    public TimeSpan PvfTime { get; set; }

    public int PvfPower { get; set; }

    public DateTime? PvfLastUpdate { get; set; }
}
