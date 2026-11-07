using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblThermometerDailyManagement
{
    public int TdmId { get; set; }

    public int TdmHour { get; set; }

    public int TdmDay { get; set; }

    public int TdmRoomNr { get; set; }

    public decimal? TdmTemperature { get; set; }
}
