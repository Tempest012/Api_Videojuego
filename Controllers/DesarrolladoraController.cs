using Api_Videojuego.Data.Servicios;
using Api_Videojuego.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Videojuego.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesarrolladorasController : ControllerBase
    {
        private DesarrolladoraServicios _desarrolladoraServicios;
        public DesarrolladorasController(DesarrolladoraServicios desarrolladoraServicios)
        {
            _desarrolladoraServicios = desarrolladoraServicios;
        }

        [HttpPost("add-desarrolladora")]
        public IActionResult AddDesarrolladora([FromBody] DesarrolladoraVM desarrolladora)
        {
            _desarrolladoraServicios.AddDesarrolladora(desarrolladora);
            return Ok();
        }
        [HttpGet("get-desarrolladora-with-juegos-by-id/{id}")]
        public IActionResult GetDesarrolladoraWithJuegos(int id)
        {
            var response = _desarrolladoraServicios.GetDesarrolladoraWithJuegos(id); 
            return Ok(response);
        }
    }
}
