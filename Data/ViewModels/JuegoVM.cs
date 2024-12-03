using System;


namespace Api_Videojuego.Data.ViewModels
{
    public class JuegoVM
    {
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public string Genero { get; set; }
        public DateTime? FechaDeLanzamiento { get; set; }
    }
}
