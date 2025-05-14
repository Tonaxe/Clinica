using Clinica.Models.dbModels;
using Microsoft.EntityFrameworkCore;

namespace DavxeShop.Persistance
{
    public class DavxeShopContext : DbContext
    {
        public DavxeShopContext(DbContextOptions<DavxeShopContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Administrativo> Administrativos { get; set; }
        public DbSet<Odontologo> Odontologos { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Responsable> Responsables { get; set; }
        public DbSet<Visita> Visitas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.id);

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.email)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.rol)
                .HasConversion<string>();

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Administrativo)
                .WithOne(a => a.Usuario)
                .HasForeignKey<Administrativo>(a => a.usuario_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Odontologo)
                .WithOne(o => o.Usuario)
                .HasForeignKey<Odontologo>(o => o.usuario_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Administrativo>()
                .HasKey(a => a.id);

            modelBuilder.Entity<Odontologo>()
                .HasKey(o => o.id);

            modelBuilder.Entity<Odontologo>()
                .HasMany(o => o.Horarios)
                .WithOne(h => h.Odontologo)
                .HasForeignKey(h => h.odontologo_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Odontologo>()
                .HasMany(o => o.Visitas)
                .WithOne(v => v.Odontologo)
                .HasForeignKey(v => v.odontologo_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Horario>()
                .HasKey(h => h.id);

            modelBuilder.Entity<Paciente>()
                .HasKey(p => p.id);

            modelBuilder.Entity<Paciente>()
                .HasIndex(p => p.email)
                .IsUnique();

            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.Responsable)
                .WithMany(r => r.Pacientes)
                .HasForeignKey(p => p.responsable_id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Paciente>()
                .HasMany(p => p.Visitas)
                .WithOne(v => v.Paciente)
                .HasForeignKey(v => v.paciente_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Responsable>()
                .HasKey(r => r.id);

            modelBuilder.Entity<Responsable>()
                .HasIndex(r => r.email)
                .IsUnique();

            modelBuilder.Entity<Visita>()
                .HasKey(v => v.id);
        }
    }
}