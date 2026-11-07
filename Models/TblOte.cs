using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblOte
{
    public int OteId { get; set; }

    public DateTime OteDate { get; set; }

    public int OteHour { get; set; }

    public decimal OtePrice { get; set; }

    public decimal OteVolume { get; set; }

    public int OteEur { get; set; }

    public DateTime? OteLastUpdate { get; set; }

    public decimal? OteExchangeRate { get; set; }

    public string? OteInterval { get; set; }

    public decimal? OtePriceInterval { get; set; }

    public int? OteWeight { get; set; }
}
