using Clinica.Models;
using DavxeShop.Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
                return NotFound(new { user = new
                {
                    id = logIn.id,
                    nombre = logIn.nombre,
                    apellido = logIn.apellido,
                    email = logIn.email,
                    rol = logIn.rol,
                }, message = "El usuario no se ha encontrado." });
            }

            return Ok(new { user = logIn, message = "El usuario se ha encontrado exitosamente." });
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
    }
}
