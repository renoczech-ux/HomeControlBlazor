using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblSolaxCloudOverview
{
    public DateTime SxoDateTime { get; set; }

    public decimal SxoYieldToday { get; set; }

    public decimal SxoPowerDc1 { get; set; }

    public decimal? SxoBatteryPower { get; set; }
}
