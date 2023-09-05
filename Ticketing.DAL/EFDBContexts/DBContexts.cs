using Microsoft.EntityFrameworkCore;
using Ticketing.DAL.Contract.Models;
using Ticketing.DAL.Mapping;

namespace Ticketing.DAL.EFDBContexts;

public class DBContexts : DbContext
{
    public DbSet<Airline> Airlines { get; set; }

    public DbSet<Airplane> Airplanes { get; set; }

    public DbSet<LinePlane> Lineplanes { get; set; }

    public DbSet<Country> Countries { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Company> Companies { get; set; }

    public DbSet<Information> Information { get; set; }

    public DBContexts(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AirlineMapping).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
