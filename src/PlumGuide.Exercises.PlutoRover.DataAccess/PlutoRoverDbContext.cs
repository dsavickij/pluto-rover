using Microsoft.EntityFrameworkCore;
using PlumGuide.Exercises.PlutoRover.DataAccess.Entities;

namespace PlumGuide.Exercises.PlutoRover.DataAccess;

public class PlutoRoverDbContext : DbContext
{
    public DbSet<Position> Positions { get; set; }

    public PlutoRoverDbContext(DbContextOptions<PlutoRoverDbContext> contextOptions)
        : base(contextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Position>()
            .ToTable("Position")
            .HasKey(p => p.Id);

        modelBuilder.Entity<Position>()
            .HasIndex(p => p.Id)
            .IsUnique();

        modelBuilder.Entity<Position>()
            .HasData(new Position(new Guid("7add428f-6811-44f9-bbd8-be6b27fe907a"), 0, 0, Direction.North));
    }
}
