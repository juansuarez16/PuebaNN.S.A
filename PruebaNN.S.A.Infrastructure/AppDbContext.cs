using Microsoft.EntityFrameworkCore;
using PruebaNN.S.A.Domain.Entities;
using PruebaNN.S.A.Infrastructure.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNN.S.A.Infrastructure
{
    public class AppDbContext: DbContext
    {
        public DbSet<Empleado> empleado { get; set; }
        public DbSet<Cargo> cargo { get; set; }        
        public DbSet<Estados> estados { get; set; }
        public DbSet<Servicio> servicio { get; set; }
        public DbSet<SolicitudServicio> solicitudServicios { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
    {
    }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SolicitudServicio>()
                .HasOne<Empleado>()
                .WithMany()
                .HasForeignKey(ss => ss.empleadoId);

            modelBuilder.Entity<SolicitudServicio>()
                .HasOne<Estados>()
                .WithMany()
                .HasForeignKey(ss => ss.estadoSolicitudId);

            modelBuilder.Entity<SolicitudServicio>()
                .HasOne<Servicio>()
                .WithMany()
                .HasForeignKey(ss => ss.servicioSolicitadoId);

            modelBuilder.Entity<Empleado>()
                .HasOne<Cargo>()
                .WithMany()
                .HasForeignKey(e => e.cargoId);

            // Configuración adicional de relaciones si es necesario

            base.OnModelCreating(modelBuilder);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(EntityBase).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property<DateTime>("CreatedDate")
                        .IsRequired();

                    modelBuilder.Entity(entityType.ClrType)
                        .Property<DateTime>("UpdatedDate")
                        .IsRequired();
                }
            }
        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is EntityBase && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((EntityBase)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((EntityBase)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
    
}
