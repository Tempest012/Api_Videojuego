using Api_Videojuego.Data.Modelo;
using Api_Videojuego.Data.ViewModels;

namespace Api_Videojuego.Data.Servicios
{
    public class DesarrolladoraServicios
    {
        private AppDbContext _context;
        public DesarrolladoraServicios(AppDbContext context)
        {
            _context = context;
        }
        //Método que nos permite agregar un nuevo Desarrolladora en la BD
        public void AddDesarrolladora(DesarrolladoraVM desarrolladora)
        {
            var _desarrolladora = new Desarrolladora()
            {
                Name = desarrolladora.Name
            };
            _context.Desarrolladoras.Add(_desarrolladora);
            _context.SaveChanges();
        }
    }
}
