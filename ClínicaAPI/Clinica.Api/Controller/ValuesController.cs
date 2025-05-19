using Clinica.Models;
using Clinica.Models.dbModels;
using DavxeShop.Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DavxeShop.Api.Controller
{
    [Route("api/Clinica")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUserService _userService;

        public ValuesController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult LogIn([FromBody] LoginRequest loginRequest)
        {
            var logIn = _userService.LogIn(loginRequest);

            if (logIn == null)
            {
                return NotFound(new { user = logIn, message = "El usuario no se ha encontrado." });
            }

            return Ok(new
            {
                user = new
                {
                    id = logIn.id,
                    nombre = logIn.nombre,
                    apellido = logIn.apellido,
                    email = logIn.email,
                    rol = logIn.rol,
                    imagen = logIn.Imagen,
                },
                message = "El usuario se ha encontrado exitosamente."
            });
        }

        [HttpPost("usuario/{id}/imagen")]
        public IActionResult SubirImagen(int id, IFormFile imagen)
        {
            var resultado = _userService.SubirImagen(id, imagen);
            if (!resultado)
            {
                return BadRequest("No se pudo subir la imagen.");
            }
            return Ok("Imagen subida correctamente.");
        }

        [HttpGet("usuario/{id}/imagen")]
        public IActionResult ObtenerImagen(int id)
        {
            var imagenBase64 = _userService.ObtenerImagen(id);
            if (imagenBase64 == null)
            {
                return NotFound("Imagen no encontrada.");
            }
            return Ok(imagenBase64);
        }

        [HttpGet("usuarios")]
        public IActionResult ObtenerAllUsuarios()
        {
            var usuarios = _userService.ObtenerAllUsuarios();
            if (usuarios == null)
            {
                return NotFound("No hay usuarios guardados.");
            }
            return Ok(new { usuarios = usuarios, message = "Usuarios devueltos exitosamente" });
        }

        [HttpGet("usuario/{id}")]
        public IActionResult UsuarioPorId(int id)
        {
            var usuario = _userService.UsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound("No hay usuarios guardados.");
            }
            return Ok(new { usuario = usuario });
        }

        [HttpPatch("editarUsuario")]
        public IActionResult CambiarDatosUsuario(User usuario)
        {
            var cambiado = _userService.CambiarDatosUsuario(usuario);
            if (cambiado == null)
            {
                return NotFound("No hay usuarios guardados.");
            }
            return Ok(new { usuario = usuario });
        }

        [HttpDelete("eliminarUsuario/{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            var eliminado = _userService.EliminarUsuario(id);

            if (!eliminado)
            {
                return NotFound($"No se encontró un usuario con ID {id}.");
            }

            return Ok(new { message = $"Usuario con ID {id} eliminado correctamente." });
        }

        [HttpPost("crearUsuario")]
        public IActionResult CrearUsuario(RegisterRequest user)
        {
            var registrado = _userService.CrearUsuario(user);

            if (!registrado)
            {
                return NotFound($"No se ha creado el usuario");
            }

            return Ok(new { message = $"Se ha creado el usuario correctamente." });
        }
        [HttpGet("pacientes")]
        public IActionResult ObtenerAllPacientes()
        {
            var pacientes = _userService.ObtenerAllPacientes();
            if (pacientes == null)
            {
                return NotFound("No hay usuarios guardados.");
            }
            return Ok(new { pacientes = pacientes, message = "Usuarios devueltos exitosamente" });
        }

        [HttpPost("crearPaciente")]
        public IActionResult CrearPaciente([FromBody] AltaPacienteRequest paciente)
        {
            var creado = _userService.CrearPaciente(paciente);

            if (creado == null)
            {
                return NotFound("El paciente no se ha dado de alta.");
            }
            return Ok(new { message = "El paciente se ha dado de alta correctamente." });
        }

        [HttpDelete("eliminarPaciente/{id}")]
        public IActionResult EliminarPaciente(int id)
        {
            var eliminado = _userService.EliminarPaciente(id);

            if (!eliminado)
            {
                return NotFound($"No se encontró el paciente con ID {id}.");
            }

            return Ok(new { message = $"El paciente con ID {id} ha sido eliminado correctamente." });
        }

        [HttpGet("paciente/{id}")]
        public IActionResult PacientePorId(int id)
        {
            var usuario = _userService.PacientePorId(id);
            if (usuario == null)
            {
                return NotFound("No hay usuarios guardados.");
            }
            return Ok(new { pacientes = usuario });
        }

        [HttpPatch("editarPaciente")]
        public IActionResult CambiarDatosPaciente(EditarPaciente paciente)
        {
            var cambiado = _userService.CambiarDatosPaciente(paciente);
            if (paciente == null)
            {
                return NotFound("No hay usuarios guardados.");
            }
            return Ok(new { pacientes = paciente });
        }

        [HttpGet("visitas")]
        public IActionResult ObtenerAllVisitas()
        {
            var visitas = _userService.ObtenerAllVisitas();
            if (visitas == null)
            {
                return NotFound("No hay visitas guardadas.");
            }
            return Ok(new { visitas = visitas, message = "Visitas devueltas exitosamente" });
        }

        [HttpGet("visitas/{id}")]
        public IActionResult ObtenerVisita(int id)
        {
            var visita = _userService.ObtenerVisita(id);
            if (visita == null)
            {
                return NotFound("No hay visita guardada.");
            }
            return Ok(new { visitas = visita, message = "Visita devuelta exitosamente" });
        }

        [HttpDelete("visitas/{id}")]
        public IActionResult EliminarVisita(int id)
        {
            var eliminado = _userService.EliminarVisita(id);

            if (!eliminado)
            {
                return NotFound($"No se encontró la visita con ID {id}.");
            }

            return Ok(new { message = $"La visita con ID {id} ha sido eliminado correctamente." });
        }

        [HttpPut("visitas/{id}")]
        public IActionResult EditarVisita(int id, [FromBody] VisitaEditarRequest visita)
        {
            var editado = _userService.EditarVisita(id, visita);
            if (!editado) 
            {
                return NotFound(new { message = "Visita no encontrada" });
            }
            
            return Ok(new { message = "Visita actualizada correctamente" });
        }

        [HttpPost("visitas")]
        public IActionResult CrearVisita([FromBody] VisitaRequest visita)
        {
            var crado = _userService.CrearVisita(visita);
            if (!crado)
            {
                return NotFound(new { message = "La visita no se ha creado correctamente" });
            }

            return Ok(new { message = "La visita se ha creado correctamente" });
        }
    }
}
