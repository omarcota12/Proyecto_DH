using Microsoft.EntityFrameworkCore;
using Proyecto_DH.Models;

namespace Proyecto_DH.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Derecho> Derechos { get; set; }
        public DbSet<Caso> Casos { get; set; }
        public DbSet<CasosPersonasDerechos> CasosPersonasDerechos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Opcional: Configuración explícita si es necesario
            modelBuilder.Entity<Administrador>()
                .HasKey(a => a.AdministradorID);

            modelBuilder.Entity<Administrador>()
                .HasOne(a => a.Usuario)
                .WithMany()
                .HasForeignKey(a => a.UsuarioID);
        }
    }
}

