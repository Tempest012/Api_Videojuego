﻿using Api_Videojuego.Data.Servicios;
using Api_Videojuego.Data.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api_Videojuego.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JuegosController : ControllerBase
    {
        public JuegosServicios _juegosServicios;
        
        public JuegosController(JuegosServicios juegosServicios)
        {
            _juegosServicios = juegosServicios;
        }



        [HttpGet("get-all-juegos")]
        public IActionResult GetAllJuegos()
        {
            var alljuegos = _juegosServicios.GetAllJgs();
            return Ok(alljuegos);
        }



        [HttpGet("get-juego-by-id/{id}")]
        public IActionResult GetJuegoById(int id)
        {
            var juego = _juegosServicios.GetJuegoById(id);
            if (juego != null)
            {
                return Ok(juego);
            }
            else
            {
                return NotFound();
            }
        }



        [HttpPost("add-juego-with-desarrolladoras")]
        public IActionResult AddJuego([FromBody]JuegoVM juego)
        {
            _juegosServicios.AddJuegoWithDesarrolladoras(juego);
            return Ok();
        }



        [HttpPut("update-juego-by-id/{id}")]
        public IActionResult UpdateJuegoById(int id, [FromBody]JuegoVM juego)
        {
            var updateJuego = _juegosServicios.UpdateJuegoById(id, juego);
            if (updateJuego != null)
            {
                return Ok(updateJuego);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpDelete("delete-juego-by-id/{id}")]
        public IActionResult DeleteJuegoById(int id)
        {
            try
            {
                _juegosServicios.DeleteJuegoById(id);
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
