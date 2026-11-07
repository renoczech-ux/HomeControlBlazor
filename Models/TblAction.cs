using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblAction
{
    public int ActId { get; set; }

    public int ActHomeNr { get; set; }

    public int ActIoTid { get; set; }

    public int? ActActive { get; set; }

    public int? ActDefaultState { get; set; }

    public decimal? ActTempMin { get; set; }

    public decimal? ActTempMax { get; set; }
}
