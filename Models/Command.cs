using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class Command
{
    public int Id { get; set; }

    public string ClientId { get; set; } = null!;

    public string DeviceId { get; set; } = null!;

    public string Action { get; set; } = null!;

    public string? Parameters { get; set; }

    public DateTime Timestamp { get; set; }
}
