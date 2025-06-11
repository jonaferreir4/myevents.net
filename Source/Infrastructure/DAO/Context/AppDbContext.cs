
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace DAO.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Inscription> Inscriptions { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime))
                {
                    modelBuilder.Entity(entityType.Name)
                        .Property<DateTime>(property.Name)
                        .HasConversion(
                            v => v.Kind == DateTimeKind.Utc ? v : v.ToUniversalTime(),
                            v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
                }
            }
        }
    }
    
    }
