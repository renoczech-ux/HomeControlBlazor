using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblShoppingListImage
{
    public int ShiId { get; set; }

    public int ShiRecordId { get; set; }

    public int ShiImageId { get; set; }

    public byte[] ShiImage { get; set; } = null!;

    public virtual TblShoppingList ShiRecord { get; set; } = null!;
}
