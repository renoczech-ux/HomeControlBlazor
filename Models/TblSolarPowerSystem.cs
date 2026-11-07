using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblSolarPowerSystem
{
    public int SpsId { get; set; }

    public DateTime SpsDateTime { get; set; }

    public decimal SpsVoltage { get; set; }

    public decimal SpsCurrent { get; set; }

    public decimal SpsPower { get; set; }

    public decimal? SpsTemperature { get; set; }

    public decimal? SpsEnergyHrAccWh { get; set; }

    public decimal? SpsEnergyDayAcc { get; set; }
}
