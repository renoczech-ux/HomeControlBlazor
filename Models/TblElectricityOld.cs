using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblElectricityOld
{
    public int SelId { get; set; }

    public int SelHomeNr { get; set; }

    public decimal SelPowerA { get; set; }

    public decimal SelReactiveA { get; set; }

    public decimal SelVoltageA { get; set; }

    public int SelIsValidA { get; set; }

    public decimal SelTotalA { get; set; }

    public decimal SelTotalReturnedA { get; set; }

    public decimal SelPowerB { get; set; }

    public decimal SelReactiveB { get; set; }

    public decimal SelVoltageB { get; set; }

    public int SelIsValidB { get; set; }

    public decimal SelTotalB { get; set; }

    public decimal SelTotalReturnedB { get; set; }

    public decimal SelPowerC { get; set; }

    public decimal SelReactiveC { get; set; }

    public decimal SelVoltageC { get; set; }

    public int SelIsValidC { get; set; }

    public decimal SelTotalC { get; set; }

    public decimal SelTotalReturnedC { get; set; }

    public decimal SelTotal { get; set; }

    public DateTime SelDateTime { get; set; }
}
