using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblShoppingList
{
    public int ShlId { get; set; }

    public string ShlName { get; set; } = null!;

    public string ShlUser { get; set; } = null!;

    public DateTime ShlDate { get; set; }

    public TimeSpan ShlTime { get; set; }

    public DateTime? ShlDateUpdate { get; set; }

    public TimeSpan? ShlTimeUpdate { get; set; }

    public int ShlStatus { get; set; }

    public int? ShlCount { get; set; }

    public virtual ICollection<TblShoppingListImage> TblShoppingListImages { get; set; } = new List<TblShoppingListImage>();
}
