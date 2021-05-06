using Microsoft.EntityFrameworkCore;
using RiebedebieApi.Data.Mappers;
using RiebedebieApi.Models;

public class RiebedebieContext : DbContext
{

    public RiebedebieContext(DbContextOptions<RiebedebieContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ChildConfiguration());
        builder.ApplyConfiguration(new RiebedebieConfiguration());
        builder.ApplyConfiguration(new ReservationConfiguration());
    }

    public DbSet<Child> Children { get; set; }
    public DbSet<Riebedebie> Riebedebies { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
}