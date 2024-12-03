﻿using Api_Videojuego.Data.Servicios;
using Api_Videojuego.Data.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(juego);
        }



        [HttpPost("add-juego")]
        public IActionResult AddJuego([FromBody]JuegoVM juego)
        {
            _juegosServicios.AddJuego(juego);
            return Ok();
        }



        [HttpPut]
        public IActionResult UpdateJuegoById(int id, [FromBody]JuegoVM juego)
        {
            var updateJuego = _juegosServicios.UpdateJuegoById(id, juego);
            return Ok(updateJuego);
        }
    }
}