using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblRelayHistory
{
    public int RlhId { get; set; }

    public int RlhRelayId { get; set; }

    public int RlhStatusOld { get; set; }

    public int RlhStatusNew { get; set; }

    public DateTime RlhDateTime { get; set; }
}
