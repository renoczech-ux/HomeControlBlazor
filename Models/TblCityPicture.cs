using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblCityPicture
{
    public int MupId { get; set; }

    public DateTime MupDateTime { get; set; }

    public byte[] MupImage { get; set; } = null!;

    public byte[]? MupThumbnail { get; set; }
}
