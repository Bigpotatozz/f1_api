using System;
using System.Collections.Generic;

namespace F1Api.Models;

public partial class Constructor
{
    public int Constructorid { get; set; }

    public string? Constructorref { get; set; }

    public string? Name { get; set; }

    public string? Nationality { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<ConstructorResult> ConstructorResults { get; set; } = new List<ConstructorResult>();

    public virtual ICollection<ConstructorStanding> ConstructorStandings { get; set; } = new List<ConstructorStanding>();

    public virtual ICollection<Qualifying> Qualifyings { get; set; } = new List<Qualifying>();
}
