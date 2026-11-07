using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class SensorDatum
{
    public int Id { get; set; }

    public string ClientId { get; set; } = null!;

    public string DeviceId { get; set; } = null!;

    public string? Data { get; set; }

    public DateTime Timestamp { get; set; }
}
