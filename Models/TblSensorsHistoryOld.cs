using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblSensorsHistoryOld
{
    public int SnsIdhistory { get; set; }

    public int SnsId { get; set; }

    public decimal SnsCurrentTemp { get; set; }

    public DateTime SnsLastUpdate { get; set; }
}
