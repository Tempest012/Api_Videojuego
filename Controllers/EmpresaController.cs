using Api_Videojuego.Data.Servicios;
using Api_Videojuego.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
            try
            {
                var newEmpresa = _empresaServicios.AddEmpresa(empresa);
                return Created(nameof(AddEmpresa), newEmpresa);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("get-empresa-by-id/{id}")]
        public IActionResult GetEmpresaById(int id)
        {
            var _response = _empresaServicios.GetEmpresaById(id);
            if (_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
        }



        [HttpGet("get-empresa-juegos-with-desarrolladoras/{id}")]
        public IActionResult GetEmpresaData(int id)
        {
            var _response = _empresaServicios.GetEmpresaData(id);
            if (_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
        }



        [HttpPut("update-empresa-by-id/{id}")]
        public IActionResult UpdateEmpresaById(int id, [FromBody] EmpresaVM empresa)
        {
            var updateEmpresa = _empresaServicios.UpdateEmpresaById(id, empresa);

            if (updateEmpresa != null)
            {
                return Ok(updateEmpresa);

            }
            else
            {
                return NotFound();
            }
        }



        [HttpDelete("delete-empresa-by-id/{id}")]
        public IActionResult DeleteEmpresaById(int id)
        {
            try
            {
                _empresaServicios.DeleteEmpresaById(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    } 
}
