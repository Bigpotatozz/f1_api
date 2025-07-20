using System;
using System.Collections.Generic;

namespace F1Api.Models;

public partial class ConstructorResult
{
    public int Constructorresultid { get; set; }

    public int? Raceid { get; set; }

    public int? Constructorid { get; set; }

    public double? Points { get; set; }

    public string? Status { get; set; }

    public virtual Constructor? Constructor { get; set; }

    public virtual Race? Race { get; set; }
}
