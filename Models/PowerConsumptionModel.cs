using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;


namespace HomeControlBlazor.Models
{
    [Keyless]
    public class PowerConsumptionModel
    {
        [Column("sel_Hour"), NotNull]
        public int Hour { get; set; }

        [Column("sel_TotalConsumptionWh"), AllowNull]
        public decimal TotalConsumptionWh { get; set; }
    }
}
