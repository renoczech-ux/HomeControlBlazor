using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblSensorsHistoryPower
{
    public int SnsIdhistory { get; set; }

    public int SnsId { get; set; }

    public DateTime? SnsLastUpdate { get; set; }

    public int? SnsLinkQuality { get; set; }

    public string? SnsState { get; set; }

    public decimal? SnsPower { get; set; }
}
