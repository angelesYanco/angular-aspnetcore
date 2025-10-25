using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NetKubernetes.Models;

namespace NetKubernetes.Data
{
    public class LoadDatabase
    {
        public static async Task InsertData(AppDbContext context, UserManager<Usuario> usuarioManager)
        {
            if (!usuarioManager.Users.Any())
            {
                var usuario = new Usuario
                {
                    Nombre = "Vaxi",
                    Apellido1 = "Drez",
                    Apellido2 = "vaxi_drez@test.com",
                    Email = "vaxi_drez@test.com",
                    UserName = "vaxi.drez",
                    Telefono = "123456789"
                };

                await usuarioManager.CreateAsync(usuario, "Vaxi123$");
            }

            if (!context.Inmuebles!.Any())
            {
                context.Inmuebles!.AddRange(
                    new Inmueble
                    {
                        Nombre = "Casa de Playa",
                        Direccion = "Malecon falso 123",
                        Precio = 220000,
                        FechaCreacion = DateTime.Now,
                    },
                    new Inmueble
                    {
                        Nombre = "Casa de Invierno",
                        Direccion = "Bosque falso 456",
                        Precio = 120000,
                        FechaCreacion = DateTime.Now,
                    }
                );
                //await context.SaveChangesAsync();
            }

            await context.SaveChangesAsync();
        }
    }
}