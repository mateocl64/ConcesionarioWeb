using ConcesionarioWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcesionarioWeb.Data;

public class ConcesionarioContext : DbContext
{
    public ConcesionarioContext(DbContextOptions<ConcesionarioContext> options) : base(options) { }

    public DbSet<TipoVehiculo> TipoVehiculos => Set<TipoVehiculo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TipoVehiculo>(entity =>
        {
            entity.ToTable("tipo_vehiculo", "dbo");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(255).IsRequired();
        });
    }
}
