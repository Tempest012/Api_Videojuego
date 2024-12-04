using Api_Videojuego.Data.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Api_Videojuego.Data
{
    public class AppDbContext:DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Juegos_Desarrolladora>().HasOne(b => b.Juegos).WithMany(ba => ba.Juegos_Desarrolladoras).HasForeignKey(bi => bi.IdJuegos);

            modelBuilder.Entity<Juegos_Desarrolladora>().HasOne(b => b.Desarrolladora).WithMany(ba => ba.Juegos_Desarrolladora).HasForeignKey(bi => bi.IdDesarrolladora);
        }
        //Utilizaremos este método para obtener y enviar datos a la BD
        public DbSet<Juegos> Juegos { get; set; }  
        public DbSet<Desarrolladora> Desarrolladoras { get; set; }
        public DbSet<Juegos_Desarrolladora> Juegos_Desarrolladoras { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
    }
}
