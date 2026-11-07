using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblEquipmentActual
{
    public int EquIoTid { get; set; }

    public DateTime EquDateTime { get; set; }

    public int EquHomeNr { get; set; }

    public string EquDescription { get; set; } = null!;

    public decimal? EquCurrentTemp { get; set; }

    public DateTime? EquLastUpdate { get; set; }

    public decimal? EquCurrentHum { get; set; }

    public decimal? EquCurrentPressure { get; set; }

    public int? EquBattery { get; set; }

    public int? EquVoltage { get; set; }

    public int? EquLinkQuality { get; set; }

    public int? EquContact { get; set; }

    public int? EquIlluminance { get; set; }

    public int? EquIlluminanceLux { get; set; }

    public int? EquOccupancy { get; set; }

    public string? EquState { get; set; }

    public decimal? EquPower { get; set; }

    public string? EquZigbeeName { get; set; }

    public decimal? EquPowerA { get; set; }

    public decimal? EquReactiveA { get; set; }

    public decimal? EquVoltageA { get; set; }

    public int? EquIsValidA { get; set; }

    public decimal? EquTotalA { get; set; }

    public decimal? EquTotalReturnedA { get; set; }

    public decimal? EquPowerB { get; set; }

    public decimal? EquReactiveB { get; set; }

    public decimal? EquVoltageB { get; set; }

    public int? EquIsValidB { get; set; }

    public decimal? EquTotalB { get; set; }

    public decimal? EquTotalReturnedB { get; set; }

    public decimal? EquPowerC { get; set; }

    public decimal? EquReactiveC { get; set; }

    public decimal? EquVoltageC { get; set; }

    public int? EquIsValidC { get; set; }

    public decimal? EquTotalC { get; set; }

    public decimal? EquTotalReturnedC { get; set; }

    public decimal? EquTotal { get; set; }

    public int? EquRelayStatus { get; set; }
}
