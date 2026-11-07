using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblReportMeRecord
{
    public int RmrId { get; set; }

    public string RmrName { get; set; } = null!;

    public string RmrDescription { get; set; } = null!;

    public string RmrStreet { get; set; } = null!;

    public string RmrCity { get; set; } = null!;

    public string? RmrGps { get; set; }

    public DateTime RmrLastUpdate { get; set; }
}
