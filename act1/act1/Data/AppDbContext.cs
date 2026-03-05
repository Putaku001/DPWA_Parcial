using act1.Models;
using Microsoft.EntityFrameworkCore;

namespace act1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Destinatario> Destinatarios { get; set; }
        public DbSet<EstadoEnvio> EstadosEnvio { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Cobro> Cobros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Usuario)
                .WithOne(u => u.Cliente)
                .HasForeignKey<Cliente>(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Destinatario>()
                .HasOne(d => d.Cliente)
                .WithMany(c => c.Destinatarios)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Envio>()
                .HasIndex(e => e.NumeroGuia)
                .IsUnique();

            modelBuilder.Entity<Envio>()
                .HasOne(e => e.Sucursal)
                .WithMany(s => s.Envios)
                .HasForeignKey(e => e.SucursalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Envio>()
                .HasOne(e => e.Cliente)
                .WithMany(c => c.Envios)
                .HasForeignKey(e => e.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Envio>()
                .HasOne(e => e.Destinatario)
                .WithMany(d => d.Envios)
                .HasForeignKey(e => e.DestinatarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Envio>()
                .HasOne(e => e.EstadoEnvio)
                .WithMany(es => es.Envios)
                .HasForeignKey(e => e.EstadoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AuditLog>()
                .HasOne(a => a.Usuario)
                .WithMany(u => u.AuditLogs)
                .HasForeignKey(a => a.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Cobro>()
                .HasOne(c => c.Envio)
                .WithMany(e => e.Cobros)
                .HasForeignKey(c => c.EnvioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cobro>()
                .HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Paquete>()
                .HasOne(p => p.Envio)
                .WithMany(e => e.Paquetes)
                .HasForeignKey(p => p.EnvioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Envio>()
                .Property(e => e.Costo)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Envio>()
                .Property(e => e.PrecioBase)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Envio>()
                .Property(e => e.Recargo)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Envio>()
                .Property(e => e.Descuento)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Envio>()
                .Property(e => e.Comision)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Paquete>()
                .Property(p => p.Peso)
                .HasColumnType("decimal(18,2)");
        }
    }
}
