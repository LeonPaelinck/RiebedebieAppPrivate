using Microsoft.EntityFrameworkCore;
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
        builder.Entity<Child>().Property(k => k.LastName).IsRequired().HasMaxLength(50);
        builder.Entity<Child>().Property(k => k.FirstName).IsRequired().HasMaxLength(50);
        builder.Entity<Child>().Property(k => k.BirthDate).IsRequired();

    }

    public DbSet<Child> Children { get; set; }
}