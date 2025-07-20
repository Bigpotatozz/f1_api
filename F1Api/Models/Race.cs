using System;
using System.Collections.Generic;

namespace F1Api.Models;

public partial class Race
{
    public int Raceid { get; set; }

    public int? Year { get; set; }

    public int? Round { get; set; }

    public int? Circuitid { get; set; }

    public string? Name { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? Time { get; set; }

    public string? Url { get; set; }

    public string? Fp1Date { get; set; }

    public string? Fp1Time { get; set; }

    public string? Fp2Date { get; set; }

    public string? Fp2Time { get; set; }

    public string? Fp3Date { get; set; }

    public string? Fp3Time { get; set; }

    public string? QualiDate { get; set; }

    public string? QualiTime { get; set; }

    public string? SprintDate { get; set; }

    public string? SprintTime { get; set; }

    public virtual Circuit? Circuit { get; set; }

    public virtual ICollection<ConstructorResult> ConstructorResults { get; set; } = new List<ConstructorResult>();

    public virtual ICollection<ConstructorStanding> ConstructorStandings { get; set; } = new List<ConstructorStanding>();

    public virtual ICollection<DriverStanding> DriverStandings { get; set; } = new List<DriverStanding>();

    public virtual ICollection<Qualifying> Qualifyings { get; set; } = new List<Qualifying>();

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
