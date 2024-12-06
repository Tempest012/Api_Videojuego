using System;

namespace Api_Videojuego.Exceptions
{
    public class EmpresaNameException:Exception
    {
        public string EmpresaName { get; set; }

        public EmpresaNameException() 
        {

        }

        public EmpresaNameException(string message) : base(message)
        {

        }

        public EmpresaNameException(string message, Exception inner) : base(message, inner)
        {

        }

        public EmpresaNameException(string message, string empresaName) : this(message)
        {
            EmpresaName = empresaName;
        }
    }
}
