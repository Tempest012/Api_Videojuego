using Api_Videojuego.Data.Servicios;
using Api_Videojuego.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Videojuego.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private EmpresaServicios _empresaServicios;
        public EmpresaController(EmpresaServicios empresaServicios)
        {
            _empresaServicios = empresaServicios;
        }

        [HttpPost("add-empresa")]
        public IActionResult AddEmpresa([FromBody] EmpresaVM empresa)
        {
            _empresaServicios.AddEmpresa(empresa);
            return Ok();
        }
    }
}
