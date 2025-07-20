using System;
using System.Collections.Generic;

namespace F1Api.Models;

public partial class Qualifying
{
    public int Qualifyid { get; set; }

    public int? Raceid { get; set; }

    public int? Driverid { get; set; }

    public int? Constructorid { get; set; }

    public int? Number { get; set; }

    public int? Position { get; set; }

    public string? Q1 { get; set; }

    public string? Q2 { get; set; }

    public string? Q3 { get; set; }

    public virtual Constructor? Constructor { get; set; }

    public virtual Driver? Driver { get; set; }

    public virtual Race? Race { get; set; }
}
