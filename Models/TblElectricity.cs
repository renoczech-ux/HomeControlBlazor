using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblElectricity
{
    public int SelId { get; set; }

    public int SelHomeNr { get; set; }

    public int SelWifiStatus { get; set; }

    public string SelWifiSsid { get; set; } = null!;

    public string SelWifiIp { get; set; } = null!;

    public int SelWifiRssi { get; set; }

    public int SelSn { get; set; }

    public string SelMac { get; set; } = null!;

    public decimal SelPowerA { get; set; }

    public decimal SelPowerFactorA { get; set; }

    public decimal SelVoltageA { get; set; }

    public int SelIsValidA { get; set; }

    public decimal SelTotalA { get; set; }

    public decimal SelTotalReturnedA { get; set; }

    public decimal SelPowerB { get; set; }

    public decimal SelPowerFactorB { get; set; }

    public decimal SelVoltageB { get; set; }

    public int SelIsValidB { get; set; }

    public decimal SelTotalB { get; set; }

    public decimal SelTotalReturnedB { get; set; }

    public decimal SelPowerC { get; set; }

    public decimal SelPowerFactorC { get; set; }

    public decimal SelVoltageC { get; set; }

    public int SelIsValidC { get; set; }

    public decimal SelTotalC { get; set; }

    public decimal SelTotalReturnedC { get; set; }

    public decimal SelTotal { get; set; }

    public decimal SelTotalPower { get; set; }

    public DateTime SelDateTime { get; set; }
}
