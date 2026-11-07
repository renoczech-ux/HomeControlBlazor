using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblSolaxCloudReport
{
    public int SxiId { get; set; }

    public string SxiInverterSn { get; set; } = null!;

    public string SxiSn { get; set; } = null!;

    public int? SxiAcpower { get; set; }

    public decimal? SxiYieldToday { get; set; }

    public decimal? SxiYieldTotal { get; set; }

    public decimal? SxiFeedInPower { get; set; }

    public int? SxiSoc { get; set; }

    public string? SxiInverterType { get; set; }

    public string? SxiInverterStatus { get; set; }

    public DateTime? SxiUploadTime { get; set; }

    public decimal? SxiBatteryPower { get; set; }

    public int? SxiPowerDc1 { get; set; }

    public string? SxiBatteryStatus { get; set; }

    public DateTime SxiLastUpdate { get; set; }
}
