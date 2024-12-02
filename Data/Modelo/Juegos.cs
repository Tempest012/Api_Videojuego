using System;

namespace Api_Videojuego.Data.Modelo
{
    public class Juegos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public string Genero { get; set; }
        public DateTime? FechaDeLanzamiento { get; set; }

    }
}
