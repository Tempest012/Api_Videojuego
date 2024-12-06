using Api_Videojuego.Data.Servicios;
using Api_Videojuego.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
            var _response = _desarrolladoraServicios.GetDesarrolladoraWithJuegos(id); 
            if (_response != null)
            {
                return Ok(_response);
            }
            else 
            { 
                return NotFound();
            }
        }



        [HttpPut("update-desarrolladora-by-id/{id}")]
        public IActionResult UpdateDesarrolladoraById(int id, [FromBody] DesarrolladoraVM desarrolladora)
        {
            var updateDesarrolladora = _desarrolladoraServicios.UpdateDesarrolladoraById(id, desarrolladora);

            if (updateDesarrolladora != null)
            {
                return Ok(updateDesarrolladora);
            }
            else
            {
                return NotFound();
            }
        }



        [HttpDelete("delete-desarrolladora-by-id/{id}")]
        public IActionResult DeleteDesarrolladoraById(int id)
        {

            try
            {
                _desarrolladoraServicios.DeleteDesarrolladoraById(id);
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
