using Api_Videojuego.Data.Modelo;
using Api_Videojuego.Data.ViewModels;

namespace Api_Videojuego.Data.Servicios
{
    public class EmpresaServicios
    {
        private AppDbContext _context;
        public EmpresaServicios(AppDbContext context)
        {
            _context = context;
        }
        //Método que nos permite agregar un nuevo Desarrolladora en la BD
        public void AddEmpresa(EmpresaVM empresa)
        {
            var _empresa = new Empresa()
            {
                Name = empresa.Name
            };
            _context.Empresas.Add(_empresa);
            _context.SaveChanges();
        }
    }
}
