using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class VwvRelayStatus
{
    public int? RlyIoTid { get; set; }

    public string? RlyDescription { get; set; }

    public int RlyRelayNr { get; set; }

    public int RlyMode { get; set; }

    public int? RlyRelayStatus { get; set; }
}
