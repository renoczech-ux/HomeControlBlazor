using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblSystemIpavailability
{
    public int SiaId { get; set; }

    public string SiaSourceIp { get; set; } = null!;

    public string SiaDestinationIp { get; set; } = null!;

    public int SiaAvailability { get; set; }

    public int SiaResponseTime { get; set; }

    public DateTime SiaDate { get; set; }

    public TimeSpan SiaTime { get; set; }
}
