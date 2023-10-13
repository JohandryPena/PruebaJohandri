using Cuenta.Domain.Entitys;
using Microsoft.EntityFrameworkCore;


namespace Cuenta.Infrastructure
{
    public class CuentaDbContext : DbContext 
    {
        public CuentaDbContext(DbContextOptions<CuentaDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

	
            modelBuilder.Entity<Cuentas>()
                .HasMany(c => c.Moviminetos)
                .WithOne(m => m.Cuenta)
                .HasForeignKey(m => m.CuentaId);

            modelBuilder.Entity<Cuentas>()
            .HasIndex(c => c.NumeroCuenta)
            .IsUnique();




            modelBuilder.Entity<Movimientos>()
                .Property(p => p.Valor)
                .HasColumnType("decimal(18,2)");

			modelBuilder.Entity<Movimientos>()
			   .Property(p => p.Saldo)
			   .HasColumnType("decimal(18,2)");

			modelBuilder.Entity<Cuentas>()
               .Property(p => p.SaldoInicial)
               .HasColumnType("decimal(18,2)");
        }   
        public DbSet<Cuentas> Cuentas { get; set; }
        public DbSet<Movimientos> Movimientos { get; set; }
        
    }
}
    