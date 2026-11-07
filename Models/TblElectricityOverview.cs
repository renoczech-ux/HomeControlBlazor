using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblElectricityOverview
{
    public DateTime EloDateTime { get; set; }

    public decimal? EloConsumption { get; set; }
}
