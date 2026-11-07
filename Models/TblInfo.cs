using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblInfo
{
    public int MsgId { get; set; }

    public DateTime MsgDate { get; set; }

    public TimeSpan MsgTime { get; set; }

    public string MsgBody { get; set; } = null!;
}
