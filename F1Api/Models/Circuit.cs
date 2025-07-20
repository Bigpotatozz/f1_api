using System;
using System.Collections.Generic;

namespace F1Api.Models;

public partial class Circuit
{
    public int Circuitid { get; set; }

    public string? Circuitref { get; set; }

    public string? Circuitname { get; set; }

    public string? Location { get; set; }

    public string? Country { get; set; }

    public double? Lat { get; set; }

    public double? Lng { get; set; }

    public double? Alt { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<Race> Races { get; set; } = new List<Race>();
}
