using System;
using System.Collections.Generic;

namespace Api_Videojuego.Data.ViewModels
{
    public class JuegoVM
    {
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public string Genero { get; set; }
        public DateTime? FechaDeLanzamiento { get; set; }
        public int EmpresaID { get; set; }
        public List<int> DesarrolladoraIDs { get; set; }
    }

    public class JuegoWithDesarrolladoraVM
    {
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public string Genero { get; set; }
        public DateTime? FechaDeLanzamiento { get; set; }

        public string EmpresaName { get; set; }
        public List<string> DesarrolladoraNames { get; set; }
    }
}
