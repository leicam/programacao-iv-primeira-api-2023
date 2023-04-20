using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Umfg.Programacaoiv2023.Primeira.Api
{
    public class Program
    {
        private static List<Cliente> _lista = new List<Cliente>()
        {
            new Cliente("Teste Um"),
            new Cliente("Teste Dois"),
        };

        public static void Main(string[] args)
        {
            var app = WebApplication.Create(args);

            app.MapGet("api/v1/Cliente", ObterTodos);
            app.MapGet("api/v1/Cliente/{id}", ObterCliente);

            app.Run();
        }

        public static async Task ObterTodos(HttpContext context)
        {
            context.Response.StatusCode = 200;
            await context.Response.WriteAsJsonAsync(_lista);
        }

        public static async Task ObterCliente(HttpContext context)
        {
            if (!context.Request.RouteValues.TryGet("id", out Guid id))
            {
                context.Response.StatusCode = 400;
                return;
            }

            var cliente = _lista.FirstOrDefault(x => x.Id == id);

            if (cliente == null)
            {
                context.Response.StatusCode = 404;
                return;
            }

            context.Response.StatusCode = 200;
            await context.Response.WriteAsJsonAsync(cliente);
        }
    }
}