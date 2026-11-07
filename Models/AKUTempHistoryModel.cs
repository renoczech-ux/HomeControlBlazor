using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace HomeControlBlazor.Models
{
    [Keyless]
    public class AKUTempHistoryModel
    {
        [Column("TimeSlot"), AllowNull]
        public DateTime LastUpdate { get; set; }

        [Column("AKUTop"), AllowNull]
        public decimal AKUTop { get; set; }

        [Column("AKUMiddle"), AllowNull]
        public decimal AKUMiddle { get; set; }

        [Column("AKUBottom"), AllowNull]
        public decimal AKUBottom { get; set; }
    }
}
