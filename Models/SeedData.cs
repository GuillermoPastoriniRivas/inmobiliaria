using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;


namespace Inmobiliaria.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new InmobiliariaContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<InmobiliariaContext>>()))
            {
                // Look for any movies.
                if (context.Inmueble.Any())
                {
                    return;   // DB has been seeded
                }

                context.Inmueble.AddRange(
                    new Inmueble
                    {
                        Ubicación = "3 de Febrero 715, Concepción del Uruguay",
                        Descripcion = "Casa ampia con dos patios, living-comedor, cocina y lavadero.",
                        FechaDePublicación = DateTime.Parse("2019-8-8"),
                        Superficie = 150,
                        Baths = 1,
                        Rooms = 2,
                        Operacion = "Venta",
                        Precio = 2800000
                    },

                    new Inmueble
                    {
                        Ubicación = "Alejo Peyret 661, Concepción del Uruguay",
                        Descripcion = "Departamento cocina-comedor y patio.",
                        FechaDePublicación = DateTime.Parse("2019-8-8"),
                        Superficie = 36,
                        Baths = 1,
                        Rooms = 1,
                        Operacion = "Alquiler",
                        Precio = 5500
                    },

                    new Inmueble
                    {
                        Ubicación = "Mariano Moreno 582, Concepción del Uruguay",
                        Descripcion = "Departamento amplio con cocina, living, comedor y patio.",
                        FechaDePublicación = DateTime.Parse("2019-8-8"),
                        Superficie = 50,
                        Baths = 1,
                        Rooms = 1,
                        Operacion = "Alquiler",
                        Precio = 6000
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
