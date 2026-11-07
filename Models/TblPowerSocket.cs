using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblPowerSocket
{
    public int PwsId { get; set; }

    public int PwsHomeId { get; set; }

    public int PwsIoTid { get; set; }

    public string PwsState { get; set; } = null!;
}
