using System;
using System.Collections.Generic;

namespace HomeControlBlazor.Models;

public partial class TblToDo
{
    public int TdoId { get; set; }

    public string TdoName { get; set; } = null!;

    public string? TdoDescription { get; set; }

    public int? TdoStatus { get; set; }

    public int? TdoCategory { get; set; }

    public int? TdoPriority { get; set; }

    public int? TdoReminder { get; set; }

    public int? TdoReminderInterval { get; set; }

    public int? TdoReminderSms { get; set; }

    public int? TdoReminderEmail { get; set; }
}
