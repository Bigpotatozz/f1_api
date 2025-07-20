using System;
using System.Collections.Generic;

namespace F1Api.Models;

public partial class DriverStanding
{
    public int Driverstanding { get; set; }

    public int? Raceid { get; set; }

    public int? Driverid { get; set; }

    public double? Points { get; set; }

    public int? Position { get; set; }

    public string? Positiontext { get; set; }

    public int? Wins { get; set; }

    public virtual Driver? Driver { get; set; }

    public virtual Race? Race { get; set; }
}
