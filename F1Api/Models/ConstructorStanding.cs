using System;
using System.Collections.Generic;

namespace F1Api.Models;

public partial class ConstructorStanding
{
    public int Constructorstandingid { get; set; }

    public int? Raceid { get; set; }

    public int? Constructorid { get; set; }

    public double? Points { get; set; }

    public int? Position { get; set; }

    public string? Positiontext { get; set; }

    public int? Wins { get; set; }

    public virtual Constructor? Constructor { get; set; }

    public virtual Race? Race { get; set; }
}
