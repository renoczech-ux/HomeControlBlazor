using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblSensor
{
    public int SnsId { get; set; }

    public string SnsDescription { get; set; } = null!;

    public decimal? SnsCurrentTemp { get; set; }

    public DateTime? SnsLastUpdate { get; set; }

    public decimal? SnsCurrentHum { get; set; }

    public decimal? SnsCurrentPressure { get; set; }

    public int? SnsBattery { get; set; }

    public int? SnsVoltage { get; set; }

    public int? SnsLinkQuality { get; set; }

    public int? SnsContact { get; set; }

    public int? SnsIlluminance { get; set; }

    public int? SnsIlluminanceLux { get; set; }

    public int? SnsOccupancy { get; set; }

    public string? SnsState { get; set; }

    public decimal? SnsPower { get; set; }

    public string? SnsZigbeeName { get; set; }
}
