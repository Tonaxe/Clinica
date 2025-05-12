using Clinica.Models;
using DavxeShop.Library.Services.Interfaces;
using DavxeShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Timers;

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
                }
                ,
                message = "El usuario se ha encontrado exitosamente."
            });
        }

        [HttpPost("logout")]
        public IActionResult LogOut([FromBody] string token)
        {
            if (token == null)
            {
                return BadRequest(new { message = "El contenido de la petición está incompleto." });
            }

            var loggedOut = _userService.LogOut(token);

            if (!loggedOut)
            {
                return StatusCode(500, new { message = "La sesión no se ha cerrado correctamente." });
            }

            return Ok(new { message = "Operación realizada correctamente." });
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
            if (usuario == null)
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

            return Ok(new { message = $"Usuario con ID {id} eliminado correctamente." } );
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

    }
}
