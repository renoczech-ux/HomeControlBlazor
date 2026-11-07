using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblEquipmentHistoryPower
{
    public int EquIdhistory { get; set; }

    public int EquId { get; set; }

    public DateTime? EquLastUpdate { get; set; }

    public int? EquLinkQuality { get; set; }

    public string? EquState { get; set; }

    public decimal? EquPower { get; set; }
}
