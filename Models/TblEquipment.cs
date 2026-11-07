using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblEquipment
{
    public int EquId { get; set; }

    public int EquHomeId { get; set; }

    public int EquIoTid { get; set; }

    public string EquDescription { get; set; } = null!;

    public string? EquZigbeeName { get; set; }

    public int? EquRelayNr { get; set; }

    public string? EquType { get; set; }

    public int? EquPosition { get; set; }

    public int? EquFloor { get; set; }

    public int? EquRoomNr { get; set; }

    public int? EquActive { get; set; }
}
