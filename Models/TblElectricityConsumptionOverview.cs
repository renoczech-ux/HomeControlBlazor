using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblElectricityConsumptionOverview
{
    public int EcoId { get; set; }

    public int EcoYear { get; set; }

    public DateTime EcoDateFrom { get; set; }

    public DateTime EcoDateTo { get; set; }

    public string EcoSupplier { get; set; } = null!;

    public decimal EcoConsumptionHt { get; set; }

    public decimal EcoConsumptionLt { get; set; }

    public decimal EcoConsumptionTotal { get; set; }

    public decimal EcoPrice { get; set; }
}
