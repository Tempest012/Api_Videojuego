using Api_Videojuego.Data.Modelo;
using Api_Videojuego.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        public DesarrolladoraWithJuegosVM GetDesarrolladoraWithJuegos(int desarrolladoraId)
        {
            var _desarrolladora = _context.Desarrolladoras.Where(n => n.Id == desarrolladoraId).Select(n => new DesarrolladoraWithJuegosVM()
            {
                Name=n.Name,
                JuegoTitles = n.Juegos_Desarrolladora.Select(n => n.Juegos.Nombre).ToList()
            }).FirstOrDefault();
            return _desarrolladora;
        }



        public Desarrolladora UpdateDesarrolladoraById(int desarrolladoraid, DesarrolladoraVM desarrolladora)
        {
            var _desarrolladora = _context.Desarrolladoras.FirstOrDefault(n => n.Id == desarrolladoraid);
            if (_desarrolladora != null)
            {
                _desarrolladora.Name = desarrolladora.Name;


                _context.SaveChanges();
            }
            return _desarrolladora;
        }



        public void DeleteDesarrolladoraById(int desarrolladoraid)
        {
            var _desarrolladora = _context.Desarrolladoras.FirstOrDefault(n => n.Id == desarrolladoraid);
            if (_desarrolladora != null)
            {
                _context.Desarrolladoras.Remove(_desarrolladora);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"La empresa con el id: {desarrolladoraid} no existe!");
            }
        }
    }
}
