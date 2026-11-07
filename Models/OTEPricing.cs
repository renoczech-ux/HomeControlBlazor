using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace HomeControlBlazor.Models
{
    [Keyless]
    public class OTEPricing
    {
        [Column("ote_Date"), AllowNull]
        public DateTime OteDate { get; set; }
       
        [Column("ote_Hour"), NotNull]
        public int OteHour { get; set; }

        [Column("ote_Price"), AllowNull]
        public decimal OtePrice { get; set; }

        [Column("ote_ExchangeRate"), AllowNull]
        public decimal OteExchangeRate { get; set;}

        [Column("ote_PriceMWh"), AllowNull]
        public decimal OtePriceMWh { get; set; }

        [Column("ote_PriceMWhCEZ"), AllowNull]
        public decimal OtePriceMWhCEZ { get; set; }

        [Column("ote_PriceMWhbezDodavatele"), AllowNull]
        public decimal OtePriceMWhbezDodavatele { get; set; }

        [Column("ote_PriceMWhElectree"), AllowNull]
        public decimal OtePriceMWhElectree { get; set; }

        [Column("ote_PriceInterval"), AllowNull]
        public decimal? OtePriceInterval { get; set; }

        [Column("ote_Interval"), AllowNull]
        public string? OteInterval { get; set; }
    }
}
