using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace F1Api.Models;

public partial class F1DataContext : DbContext
{
    public F1DataContext()
    {
    }

    public F1DataContext(DbContextOptions<F1DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Circuit> Circuits { get; set; }

    public virtual DbSet<Constructor> Constructors { get; set; }

    public virtual DbSet<ConstructorResult> ConstructorResults { get; set; }

    public virtual DbSet<ConstructorStanding> ConstructorStandings { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<DriverStanding> DriverStandings { get; set; }

    public virtual DbSet<LapTime> LapTimes { get; set; }

    public virtual DbSet<PitStop> PitStops { get; set; }

    public virtual DbSet<Qualifying> Qualifyings { get; set; }

    public virtual DbSet<Race> Races { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=f1_data;Username=postgres;Password=1924");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Circuit>(entity =>
        {
            entity.HasKey(e => e.Circuitid).HasName("circuits_pkey");

            entity.ToTable("circuits");

            entity.Property(e => e.Circuitid).HasColumnName("circuitid");
            entity.Property(e => e.Alt).HasColumnName("alt");
            entity.Property(e => e.Circuitname)
                .HasMaxLength(60)
                .HasColumnName("circuitname");
            entity.Property(e => e.Circuitref)
                .HasMaxLength(30)
                .HasColumnName("circuitref");
            entity.Property(e => e.Country)
                .HasMaxLength(40)
                .HasColumnName("country");
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.Lng).HasColumnName("lng");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .HasColumnName("location");
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .HasColumnName("url");
        });

        modelBuilder.Entity<Constructor>(entity =>
        {
            entity.HasKey(e => e.Constructorid).HasName("constructors_pkey");

            entity.ToTable("constructors");

            entity.Property(e => e.Constructorid).HasColumnName("constructorid");
            entity.Property(e => e.Constructorref)
                .HasMaxLength(50)
                .HasColumnName("constructorref");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Nationality)
                .HasMaxLength(30)
                .HasColumnName("nationality");
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .HasColumnName("url");
        });

        modelBuilder.Entity<ConstructorResult>(entity =>
        {
            entity.HasKey(e => e.Constructorresultid).HasName("constructor_results_pkey");

            entity.ToTable("constructor_results");

            entity.Property(e => e.Constructorresultid).HasColumnName("constructorresultid");
            entity.Property(e => e.Constructorid).HasColumnName("constructorid");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.Raceid).HasColumnName("raceid");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .HasColumnName("status");

            entity.HasOne(d => d.Constructor).WithMany(p => p.ConstructorResults)
                .HasForeignKey(d => d.Constructorid)
                .HasConstraintName("constructor_results_constructorid_fkey");

            entity.HasOne(d => d.Race).WithMany(p => p.ConstructorResults)
                .HasForeignKey(d => d.Raceid)
                .HasConstraintName("constructor_results_raceid_fkey");
        });

        modelBuilder.Entity<ConstructorStanding>(entity =>
        {
            entity.HasKey(e => e.Constructorstandingid).HasName("constructor_standings_pkey");

            entity.ToTable("constructor_standings");

            entity.Property(e => e.Constructorstandingid).HasColumnName("constructorstandingid");
            entity.Property(e => e.Constructorid).HasColumnName("constructorid");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Positiontext)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("positiontext");
            entity.Property(e => e.Raceid).HasColumnName("raceid");
            entity.Property(e => e.Wins).HasColumnName("wins");

            entity.HasOne(d => d.Constructor).WithMany(p => p.ConstructorStandings)
                .HasForeignKey(d => d.Constructorid)
                .HasConstraintName("constructor_standings_constructorid_fkey");

            entity.HasOne(d => d.Race).WithMany(p => p.ConstructorStandings)
                .HasForeignKey(d => d.Raceid)
                .HasConstraintName("constructor_standings_raceid_fkey");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Driverid).HasName("drivers_pkey");

            entity.ToTable("drivers");

            entity.Property(e => e.Driverid).HasColumnName("driverid");
            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("code");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Driverref)
                .HasMaxLength(60)
                .HasColumnName("driverref");
            entity.Property(e => e.Forename)
                .HasMaxLength(30)
                .HasColumnName("forename");
            entity.Property(e => e.Nationality)
                .HasMaxLength(30)
                .HasColumnName("nationality");
            entity.Property(e => e.Number)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("number");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .HasColumnName("surname");
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .HasColumnName("url");
        });

        modelBuilder.Entity<DriverStanding>(entity =>
        {
            entity.HasKey(e => e.Driverstanding).HasName("driver_standings_pkey");

            entity.ToTable("driver_standings");

            entity.Property(e => e.Driverstanding).HasColumnName("driverstanding");
            entity.Property(e => e.Driverid).HasColumnName("driverid");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Positiontext)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("positiontext");
            entity.Property(e => e.Raceid).HasColumnName("raceid");
            entity.Property(e => e.Wins).HasColumnName("wins");

            entity.HasOne(d => d.Driver).WithMany(p => p.DriverStandings)
                .HasForeignKey(d => d.Driverid)
                .HasConstraintName("driver_standings_driverid_fkey");

            entity.HasOne(d => d.Race).WithMany(p => p.DriverStandings)
                .HasForeignKey(d => d.Raceid)
                .HasConstraintName("driver_standings_raceid_fkey");
        });

        modelBuilder.Entity<LapTime>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("lap_times");

            entity.Property(e => e.Driverid).HasColumnName("driverid");
            entity.Property(e => e.Lap).HasColumnName("lap");
            entity.Property(e => e.Miliseconds).HasColumnName("miliseconds");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Raceid).HasColumnName("raceid");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.Driver).WithMany()
                .HasForeignKey(d => d.Driverid)
                .HasConstraintName("lap_times_driverid_fkey");

            entity.HasOne(d => d.Race).WithMany()
                .HasForeignKey(d => d.Raceid)
                .HasConstraintName("lap_times_raceid_fkey");
        });

        modelBuilder.Entity<PitStop>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("pit_stops");

            entity.Property(e => e.Driverid).HasColumnName("driverid");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Lap).HasColumnName("lap");
            entity.Property(e => e.Miliseconds).HasColumnName("miliseconds");
            entity.Property(e => e.Raceid).HasColumnName("raceid");
            entity.Property(e => e.Stop).HasColumnName("stop");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.Driver).WithMany()
                .HasForeignKey(d => d.Driverid)
                .HasConstraintName("pit_stops_driverid_fkey");

            entity.HasOne(d => d.Race).WithMany()
                .HasForeignKey(d => d.Raceid)
                .HasConstraintName("pit_stops_raceid_fkey");
        });

        modelBuilder.Entity<Qualifying>(entity =>
        {
            entity.HasKey(e => e.Qualifyid).HasName("qualifying_pkey");

            entity.ToTable("qualifying");

            entity.Property(e => e.Qualifyid).HasColumnName("qualifyid");
            entity.Property(e => e.Constructorid).HasColumnName("constructorid");
            entity.Property(e => e.Driverid).HasColumnName("driverid");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Q1)
                .HasMaxLength(20)
                .HasColumnName("q1");
            entity.Property(e => e.Q2)
                .HasMaxLength(20)
                .HasColumnName("q2");
            entity.Property(e => e.Q3)
                .HasMaxLength(20)
                .HasColumnName("q3");
            entity.Property(e => e.Raceid).HasColumnName("raceid");

            entity.HasOne(d => d.Constructor).WithMany(p => p.Qualifyings)
                .HasForeignKey(d => d.Constructorid)
                .HasConstraintName("qualifying_constructorid_fkey");

            entity.HasOne(d => d.Driver).WithMany(p => p.Qualifyings)
                .HasForeignKey(d => d.Driverid)
                .HasConstraintName("qualifying_driverid_fkey");

            entity.HasOne(d => d.Race).WithMany(p => p.Qualifyings)
                .HasForeignKey(d => d.Raceid)
                .HasConstraintName("qualifying_raceid_fkey");
        });

        modelBuilder.Entity<Race>(entity =>
        {
            entity.HasKey(e => e.Raceid).HasName("races_pkey");

            entity.ToTable("races");

            entity.Property(e => e.Raceid).HasColumnName("raceid");
            entity.Property(e => e.Circuitid).HasColumnName("circuitid");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Fp1Date)
                .HasMaxLength(10)
                .HasColumnName("fp1_date");
            entity.Property(e => e.Fp1Time)
                .HasMaxLength(10)
                .HasColumnName("fp1_time");
            entity.Property(e => e.Fp2Date)
                .HasMaxLength(10)
                .HasColumnName("fp2_date");
            entity.Property(e => e.Fp2Time)
                .HasMaxLength(10)
                .HasColumnName("fp2_time");
            entity.Property(e => e.Fp3Date)
                .HasMaxLength(10)
                .HasColumnName("fp3_date");
            entity.Property(e => e.Fp3Time)
                .HasMaxLength(10)
                .HasColumnName("fp3_time");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.QualiDate)
                .HasMaxLength(10)
                .HasColumnName("quali_date");
            entity.Property(e => e.QualiTime)
                .HasMaxLength(10)
                .HasColumnName("quali_time");
            entity.Property(e => e.Round).HasColumnName("round");
            entity.Property(e => e.SprintDate)
                .HasMaxLength(10)
                .HasColumnName("sprint_date");
            entity.Property(e => e.SprintTime)
                .HasMaxLength(10)
                .HasColumnName("sprint_time");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .HasColumnName("url");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Circuit).WithMany(p => p.Races)
                .HasForeignKey(d => d.Circuitid)
                .HasConstraintName("races_circuitid_fkey");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.Resultid).HasName("results_pkey");

            entity.ToTable("results");

            entity.Property(e => e.Resultid).HasColumnName("resultid");
            entity.Property(e => e.Constructorid).HasColumnName("constructorid");
            entity.Property(e => e.Driverid).HasColumnName("driverid");
            entity.Property(e => e.Fastestlap).HasColumnName("fastestlap");
            entity.Property(e => e.Fastestlapspeed).HasColumnName("fastestlapspeed");
            entity.Property(e => e.Fastestlaptime).HasColumnName("fastestlaptime");
            entity.Property(e => e.Grid).HasColumnName("grid");
            entity.Property(e => e.Laps).HasColumnName("laps");
            entity.Property(e => e.Miliseconds).HasColumnName("miliseconds");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Positionorder).HasColumnName("positionorder");
            entity.Property(e => e.Positiontext)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("positiontext");
            entity.Property(e => e.Raceid).HasColumnName("raceid");
            entity.Property(e => e.Rank).HasColumnName("rank");
            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Time)
                .HasMaxLength(30)
                .HasColumnName("time");

            entity.HasOne(d => d.Driver).WithMany(p => p.Results)
                .HasForeignKey(d => d.Driverid)
                .HasConstraintName("results_driverid_fkey");

            entity.HasOne(d => d.Race).WithMany(p => p.Results)
                .HasForeignKey(d => d.Raceid)
                .HasConstraintName("results_raceid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
