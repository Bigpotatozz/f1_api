using System;
using System.Collections.Generic;

namespace F1Api.Models;

public partial class Driver
{
    public int Driverid { get; set; }

    public string? Driverref { get; set; }

    public string? Number { get; set; }

    public string? Code { get; set; }

    public string? Forename { get; set; }

    public string? Surname { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Nationality { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<DriverStanding> DriverStandings { get; set; } = new List<DriverStanding>();

    public virtual ICollection<Qualifying> Qualifyings { get; set; } = new List<Qualifying>();

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
