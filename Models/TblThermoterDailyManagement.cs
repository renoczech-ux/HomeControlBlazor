using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblThermoterDailyManagement
{
    public int TdmId { get; set; }

    public int TdmHour { get; set; }

    public int TdmDay { get; set; }

    public int TdmSensorId { get; set; }

    public int TdmTemperature { get; set; }
}
