using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblCez
{
    public int CezId { get; set; }

    public DateTime CezDate { get; set; }

    public TimeSpan CezTime { get; set; }

    public int CezT1 { get; set; }

    public int CezT2 { get; set; }

    public int? CezPrice { get; set; }

    public int? CezMeasurementMonth { get; set; }

    public int? CezMeasurementYear { get; set; }

    public int? CezMonthlyConsumptionkWh { get; set; }
}
