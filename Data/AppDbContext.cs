using Microsoft.EntityFrameworkCore;
using CallCenterBackend.Models;

namespace CallCenterBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Aquí registras tus tablas (DbSets)
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Capacitador> Capacitadores { get; set; }
        public DbSet<Capacitacion> Capacitaciones { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        public DbSet<Participacion> Participaciones { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }
        public DbSet<CapacitacionCapacitador> CapacitacionCapacitadores { get; set; }

        // Configuraciones adicionales (relaciones, nombres de tabla, etc.)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Opcional: asignar nombres exactos de tablas (si no coinciden con el plural)
            modelBuilder.Entity<Colaborador>().ToTable("Colaborador");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Capacitador>().ToTable("Capacitador");
            modelBuilder.Entity<Capacitacion>().ToTable("Capacitacion");
            modelBuilder.Entity<Sesion>().ToTable("Sesion");
            modelBuilder.Entity<Participacion>().ToTable("Participacion");
            modelBuilder.Entity<Evaluacion>().ToTable("Evaluacion");
            modelBuilder.Entity<CapacitacionCapacitador>().ToTable("CapacitacionCapacitador");
        }
    }
}
