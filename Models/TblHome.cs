using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblHome
{
    public int HomId { get; set; }

    public int HomHomeNr { get; set; }

    public string? HomAction { get; set; }

    public string HomDescription { get; set; } = null!;

    public int HomState { get; set; }

    public int HomDefaultState { get; set; }

    public int? HomPin { get; set; }
}
