using System.Collections.Generic;

namespace Api_Videojuego.Data.Modelo
{
    public class Desarrolladora
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Propiedades de navegación(en esta parte es donde especificamos las relaciones)

        public List<Juegos_Desarrolladora> Juegos_Desarrolladora {  get; set; }

    }
}
