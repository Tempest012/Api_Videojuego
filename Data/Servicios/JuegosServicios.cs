using Api_Videojuego.Data.Modelo;
using Api_Videojuego.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api_Videojuego.Data.Servicios
{
    public class JuegosServicios
    {
        private AppDbContext _context;
        public JuegosServicios(AppDbContext context)
        {
            _context = context;
        }

        // Método que nos permite agregar un nuevo juego en la BD
        public void AddJuegoWithDesarrolladoras(JuegoVM juego)
        {
            var _juego = new Juegos()
            {
                Nombre = juego.Nombre,
                Descripción = juego.Descripción,
                Genero = juego.Genero,
                FechaDeLanzamiento = juego.FechaDeLanzamiento,
                EmpresaId = juego.EmpresaID
            };
            _context.Juegos.Add(_juego);
            _context.SaveChanges();

            foreach(var id in juego.DesarrolladoraIDs)
            {
                var _juegos_Desarrolladora = new Juegos_Desarrolladora()
                {
                    IdJuegos= _juego.Id,
                    IdDesarrolladora = id
                };
                _context.Juegos_Desarrolladoras.Add(_juegos_Desarrolladora);
                _context.SaveChanges();
            }
        }


        // Método que nos permite obtener una lista de todos los juegos de la BD
        public List<Juegos> GetAllJgs() => _context.Juegos.ToList();


        // Método que nos permite obtener el juego que estamos pidiendo de la BD
        public JuegoWithDesarrolladoraVM GetJuegoById(int juegosid)
        {
            var _juegoWithDesarrolladoras = _context.Juegos.Where(n => n.Id == juegosid).Select(juego => new JuegoWithDesarrolladoraVM()
            {
                Nombre = juego.Nombre,
                Descripción = juego.Descripción,
                Genero = juego.Genero,
                FechaDeLanzamiento = juego.FechaDeLanzamiento,
                EmpresaName = juego.Empresa.Name,
                DesarrolladoraNames = juego.Juegos_Desarrolladoras.Select(n => n.Desarrolladora.Name).ToList()
            }).FirstOrDefault();
            return _juegoWithDesarrolladoras;
        }


        // Método que nos permite modificar un juego que se encuentra en la BD
        public Juegos UpdateJuegoById(int juegosid, JuegoVM juego) 
        {
            var _juego = _context.Juegos.FirstOrDefault(n => n.Id == juegosid);
            if (_juego != null)
            {
                _juego.Nombre = juego.Nombre;
                _juego.Descripción = juego.Descripción;
                _juego.Genero = juego.Genero;
                _juego.FechaDeLanzamiento = juego.FechaDeLanzamiento;

                _context.SaveChanges();
            }
            return _juego;
        }

        public void DeleteJuegoById(int juegosid)
        {
            var _juego = _context.Juegos.FirstOrDefault(n => n.Id==juegosid);
            if(_juego != null)
            {
                _context.Juegos.Remove( _juego );
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"La empresa con el id: {juegosid} no existe!");
            }
        }
    }
}
