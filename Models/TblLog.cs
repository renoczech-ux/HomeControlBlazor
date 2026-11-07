using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblLog
{
    public int LogId { get; set; }

    public DateTime LogDateTime { get; set; }

    public string LogClass { get; set; } = null!;

    public string LogMethod { get; set; } = null!;

    public string LogError { get; set; } = null!;
}
