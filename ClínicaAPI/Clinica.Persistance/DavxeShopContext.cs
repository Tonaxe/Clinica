using Clinica.Models;
using DavxeShop.Models;
using Microsoft.EntityFrameworkCore;

namespace DavxeShop.Persistance
{
    public class DavxeShopContext : DbContext
    {
        public DavxeShopContext(DbContextOptions<DavxeShopContext> options) : base(options) { }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Pacientes> Pacientes { get; set; }
        public DbSet<Responsables> Responsables { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuarios>().HasKey(u => u.id);
            modelBuilder.Entity<Session>().HasKey(u => u.SessionId);
            modelBuilder.Entity<Pacientes>().HasKey(u => u.id);
            modelBuilder.Entity<Responsables>().HasKey(u => u.id);
        }
    }
}
