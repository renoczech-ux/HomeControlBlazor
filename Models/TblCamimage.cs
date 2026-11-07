using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblCamimage
{
    public int CpiId { get; set; }

    public int CpiCamid { get; set; }

    public DateTime CpiDate { get; set; }

    public TimeSpan CpiTime { get; set; }

    public byte[] CpiImage { get; set; } = null!;
}
