using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Approvado.Models;

namespace Approvado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tn5250Controller : ControllerBase
    {
        public Tn5250Controller()
        {
        }

        [HttpGet("")]
        public async Task<ActionResult> StartTN5250()
        {
            try
        {
            // Inicia la aplicación TN5250
            StartTN5250Application("/Applications/TN5250.app");

            // Aquí puedes agregar la lógica para automatizar la interacción con la aplicación
            // utilizando herramientas de automatización de GUI o integración con APIs específicas.

            return Ok("TN5250 iniciado con éxito.");
        }
        catch (Exception ex)
        {
            return InternalServerError(new Exception($"Error al iniciar TN5250: {ex.Message}"));
        }
        }

        private ActionResult InternalServerError(Exception exception)
        {
            throw new NotImplementedException();
        }

        private void StartTN5250Application(string applicationPath)
    {
        // Verifica si el path de la aplicación es válido
        if (string.IsNullOrEmpty(applicationPath))
        {
            throw new ArgumentException("La ruta de la aplicación no puede estar vacía.", nameof(applicationPath));
        }

        // Configura y lanza la aplicación TN5250
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "open",
            Arguments = $"-a \"{applicationPath}\"",
            UseShellExecute = false,
            RedirectStandardInput = true,
            RedirectStandardOutput = true
        };

        Process process = Process.Start(startInfo);
        if (process == null)
        {
            throw new InvalidOperationException("No se pudo iniciar el proceso TN5250.");
        }

        // Aquí puedes agregar la lógica para interactuar con la aplicación TN5250,
        // por ejemplo, enviar comandos o leer la salida.

        // Ejemplo: Espera 10 segundos y luego envía un comando
        Task.Delay(10000).ContinueWith(t =>
        {
            process.StandardInput.WriteLine("aaa");
            Console.WriteLine(process.StandardOutput.ReadToEnd());
            Console.WriteLine($"TN5250 iniciado con PID: {process.Id}");
        });
    }

      
    }
}