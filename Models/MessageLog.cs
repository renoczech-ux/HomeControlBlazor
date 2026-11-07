using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class MessageLog
{
    public long Id { get; set; }

    public DateTime Timestamp { get; set; }

    public string ClientEndpoint { get; set; } = null!;

    public string MessageContent { get; set; } = null!;

    public string? ResponseContent { get; set; }

    public int? ProcessingTimeMs { get; set; }

    public DateTime CreatedAt { get; set; }
}
