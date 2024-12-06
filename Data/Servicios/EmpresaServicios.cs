using Api_Videojuego.Data.Modelo;
using Api_Videojuego.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System;

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
        public Empresa AddEmpresa(EmpresaVM empresa)
        {
            var _empresa = new Empresa()
            {
                Name = empresa.Name
            };
            _context.Empresas.Add(_empresa);
            _context.SaveChanges();

            return _empresa;
        }



        public Empresa GetEmpresaById(int id) => _context.Empresas.FirstOrDefault(n => n.Id == id);



        public EmpresaWithJuegosAndDesarrolladorasVM GetEmpresaData(int empresaId)
        {
            var _empresaData = _context.Empresas.Where(n => n.Id == empresaId)
                .Select(n => new EmpresaWithJuegosAndDesarrolladorasVM()
                {
                    Name = n.Name,
                    JuegoDesarrolladoras = n.Juegos.Select(n => new JuegoDesarrolladoraVM()
                    {
                        JuegoName = n.Nombre,
                        JuegoDesarrolladoras = n.Juegos_Desarrolladoras.Select(n => n.Juegos.Nombre).ToList()
                    }).ToList()
                }).FirstOrDefault();
            return _empresaData;
        }

        public Empresa UpdateEmpresaById(int empresaid, EmpresaVM empresa)
        {
            var _empresa = _context.Empresas.FirstOrDefault(n => n.Id == empresaid);
            if (_empresa != null)
            {
                _empresa.Name = empresa.Name;

                _context.SaveChanges();
            }
            return _empresa;
        }


        internal void DeleteEmpresaById(int id)
        {
            var _empresa = _context.Empresas.FirstOrDefault(n => n.Id == id);
            if (_empresa != null)
            {
                _context.Empresas.Remove(_empresa);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"La empresa con el id: {id} no existe!");
            }
        }

       
    }
}
