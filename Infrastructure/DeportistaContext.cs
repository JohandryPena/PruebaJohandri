using Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class DeportistaContext : DbContext
{
    public DeportistaContext(DbContextOptions<DeportistaContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PesoDeportista>()
            .HasOne(p => p.Deportista)
            .WithMany(d => d.Pesos)  
            .HasForeignKey(p => p.DeportistaId);
    }

    public DbSet<Deportista> Deportistas { get; set; }
    public DbSet<PesoDeportista> PesosDeportistas { get; set; }
}