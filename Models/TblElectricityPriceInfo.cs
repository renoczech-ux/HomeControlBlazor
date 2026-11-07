using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblElectricityPriceInfo
{
    public int EpiId { get; set; }

    public int EpiYear { get; set; }

    public string EpiProvider { get; set; } = null!;

    public DateTime EpiProviderPriceValidFrom { get; set; }

    public DateTime EpiProviderPriceValidTo { get; set; }

    public string EpiDistribution { get; set; } = null!;

    public DateTime EpiDistributioPriceValidFrom { get; set; }

    public DateTime EpiDistributioPriceValidTo { get; set; }

    public string EpiTarifName { get; set; } = null!;

    public decimal EpiProviderPriceTarifHigh1 { get; set; }

    public decimal EpiProviderPriceTarifLow2 { get; set; }

    public decimal EpiProviderPriceFixedPayment3 { get; set; }

    public decimal EpiDistributioPriceTarifHigh4 { get; set; }

    public decimal EpiDistributioPriceTarifLow5 { get; set; }

    public decimal EpiBreaker3x10with3x256 { get; set; }

    public decimal EpiBreaker3x10with3x167 { get; set; }

    public decimal EpiBreaker3x16with3x208 { get; set; }

    public decimal EpiBreaker3x20with3x259 { get; set; }

    public decimal EpiBreaker3x25with3x3210 { get; set; }

    public decimal EpiBreaker3x32with3x4011 { get; set; }

    public decimal EpiBreaker3x40with3x5012 { get; set; }

    public decimal EpiBreaker3x50with3x6313 { get; set; }

    public decimal EpiBreaker3x63with3x8014 { get; set; }

    public decimal EpiBreaker3x80with3x10015 { get; set; }

    public decimal EpiBreaker3x100with3x12516 { get; set; }

    public decimal EpiBreaker3x125with3x16017 { get; set; }

    public decimal EpiBreaker3x160with1x118 { get; set; }

    public decimal EpiBreaker3x63with1x119 { get; set; }

    public decimal EpiBreaker1x25with1x120 { get; set; }

    public decimal EpiElectricityDph21 { get; set; }

    public decimal EpiSystemServicesPrice22 { get; set; }

    public decimal EpiOteactivities23 { get; set; }

    public decimal EpiPozebreaker24 { get; set; }

    public decimal EpiPozeconsumption25 { get; set; }

    public decimal? EpiFinalPriceTarifHigh26 { get; set; }

    public decimal? EpiFinalPriceTarifLow27 { get; set; }

    public decimal? EpiMonthlyFixedCosts28 { get; set; }

    public decimal? EpiPozefinalPriceBreaker29 { get; set; }

    public decimal? EpiPozefinalPriceConsumption30 { get; set; }

    public decimal? EpiServiceMarketPaymentMwh { get; set; }
}
