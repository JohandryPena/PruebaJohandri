using Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DeportistaDbContext : DbContext 
    {
        public DeportistaDbContext(DbContextOptions<DeportistaDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deportista>()
                .HasMany(d => d.Pesos)
                .WithOne(p => p.Deportista)
                .HasForeignKey(p => p.DeportistaId);

        }
        public DbSet<Deportista?> Deportistas { get; set; }
        public DbSet<PesoDeportista> PesoDeportistas { get; set; }
        
    }
}
    