using Api_Videojuego.Data.Modelo;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Api_Videojuego.Data
{
    public class AppDbInitialer
    {
        //Método que agregar datos a nuestra BD
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Juegos.Any())
                {
                    context.Juegos.AddRange(new Juegos()
                    {
                        Nombre = "Primer juego",
                        Descripción = "La primera descripción",
                        Genero = "El primer genero",
                        FechaDeLanzamiento = DateTime.Now,
                    },
                    new Juegos()
                    {
                        Nombre = "Segundo juego",
                        Descripción = "La Segunda descripción",
                        Genero = "el segundo genero",
                        FechaDeLanzamiento = DateTime.Now,
                    });
                    context.SaveChanges();

                }
            }
        }
    }
}
