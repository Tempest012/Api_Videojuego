using System.Collections.Generic;

namespace Api_Videojuego.Data.Modelo
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Propiedades de navegación
        public List<Juegos> Juegos { get; set; }

    }
}
