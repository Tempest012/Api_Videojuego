using System.Collections.Generic;

namespace Api_Videojuego.Data.ViewModels
{
    public class DesarrolladoraVM
    {
        public string Name { get; set; }
    }

    public class DesarrolladoraWithJuegosVM
    {
        public string Name { get; set; }
        public List<string> JuegoTitles { get; set; }
    }
}
