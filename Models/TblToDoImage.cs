using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblToDoImage
{
    public int TdpId { get; set; }

    public int TdpToDoId { get; set; }

    public string? TdpDescription { get; set; }

    public byte[]? TdpImage { get; set; }
}
