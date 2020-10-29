using System;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class InventarioContext : DbContext
    {
        public InventarioContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Insumo> Insumos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Solicitud>()
            .HasOne<Asignatura>().WithMany()
            .HasForeignKey(p => p.CodigoAsignatura);

            modelBuilder.Entity<Detalle>()
            .HasOne<Insumo>().WithMany()
            .HasForeignKey(p => p.CodigoInsumo);
        }
    }
}
