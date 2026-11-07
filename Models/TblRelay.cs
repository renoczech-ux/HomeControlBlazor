using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblRelay
{
    public int RlyId { get; set; }

    public int RlyHomeId { get; set; }

    public int RlyRelayNr { get; set; }

    public int RlyState { get; set; }
}
