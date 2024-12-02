using Api_Videojuego.Data.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Api_Videojuego.Data
{
    public class AppDbContext:DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Juegos> Juegos { get; set; }  
    }
}
