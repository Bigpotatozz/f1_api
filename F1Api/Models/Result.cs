using System;
using System.Collections.Generic;

namespace F1Api.Models;

public partial class Result
{
    public int Resultid { get; set; }

    public int? Raceid { get; set; }

    public int? Driverid { get; set; }

    public int? Constructorid { get; set; }

    public int? Number { get; set; }

    public int? Grid { get; set; }

    public int? Position { get; set; }

    public string? Positiontext { get; set; }

    public int? Positionorder { get; set; }

    public double? Points { get; set; }

    public int? Laps { get; set; }

    public string? Time { get; set; }

    public int? Miliseconds { get; set; }

    public int? Fastestlap { get; set; }

    public int? Rank { get; set; }

    public TimeOnly? Fastestlaptime { get; set; }

    public double? Fastestlapspeed { get; set; }

    public int? Statusid { get; set; }

    public virtual Driver? Driver { get; set; }

    public virtual Race? Race { get; set; }
}
