using System.Collections.Generic;

namespace Api_Videojuego.Data.ViewModels
{
    public class EmpresaVM
    {
        public string Name { get; set; }
    }

    

    public class EmpresaWithJuegosAndDesarrolladorasVM
    {
        public string Name { get; set; }
        public List<JuegoDesarrolladoraVM> JuegoDesarrolladoras { get; set; }
    }



    public class JuegoDesarrolladoraVM
    {
        public string JuegoName { get; set; }
        public List<string> JuegoDesarrolladoras { get; set; }
    }
}
