using System;
using System.Collections.Generic;

namespace F1Api.Models;

public partial class LapTime
{
    public int? Raceid { get; set; }

    public int? Driverid { get; set; }

    public int? Lap { get; set; }

    public int? Position { get; set; }

    public TimeOnly? Time { get; set; }

    public int? Miliseconds { get; set; }

    public virtual Driver? Driver { get; set; }

    public virtual Race? Race { get; set; }
}
