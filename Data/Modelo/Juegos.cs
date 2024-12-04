using System;
using System.Collections.Generic;

namespace Api_Videojuego.Data.Modelo
{
    public class Juegos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public string Genero { get; set; }
        public DateTime? FechaDeLanzamiento { get; set; }

        //Propiedades de navegación (en esta parte es donde "mapeamos")
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public List<Juegos_Desarrolladora> Juegos_Desarrolladoras { get; set; }
    }
}
