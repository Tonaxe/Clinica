using Azure.Core;
using DavxeShop.Library.Services.Interfaces;
using DavxeShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Xabe.FFmpeg;

namespace DavxeShop.Api.Controller
{
    [Route("api/DavxeShop")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidations _validations;
        private readonly string inputFolder = @"C:\Users\yassi\Desktop\video sufi\";
        private readonly string outputFolder = @"C:\Users\yassi\Desktop\video sufi\mp4\";

        public ValuesController(IUserService userService, IValidations validations)
        {
            _userService = userService;
            _validations = validations;
        }

        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();

            if (users == null || !users.Any())
            {
                return NotFound(new { message = "El usuario no se ha encontrado." });
            }

            return Ok(new { users = users });
        }

        [HttpGet("users/{UserId}")]
        public IActionResult GetUser(int UserId)
        {
            if (UserId <= 0)
            {
                return BadRequest(new { message = "El contenido de la petición está incompleto." });
            }

            var user = _userService.GetUser(UserId);

            if (user == null)
            {
                return NotFound(new { message = "El usuario no se ha encontrado." });
            }

            return Ok(new { user = user });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            if (request == null || HasNullOrEmptyProperties(request))
            {
                return BadRequest(new { message = "El contenido de la petición está incompleto." });
            }

            bool validatedEmail = _validations.ValidEmail(request.Email);

            if (!validatedEmail)
            {
                return BadRequest(new { message = "El email no es válido." });
            }

            bool validatedDNI = _validations.ValidDni(request.DNI);

            if (!validatedDNI)
            {
                return BadRequest(new { message = "El DNI no es válido." });
            }

            bool userExists = _validations.UserExists(request.Name, request.Email, request.DNI);

            if (userExists)
            {
                return NotFound(new { message = "El usuario ya existe." });
            }

            var requestHashed = _userService.RequestHashed(request);

            bool userSaved = _userService.SaveUser(requestHashed);

            if (!userSaved)
            {
                return StatusCode(500, new { message = "El usuario no se ha registrado." });
            }

            return Ok(new { message = "El usuario se ha registrado correctamente" });

        }

        [HttpPost("login")]
        public IActionResult LogIn([FromBody] LogInRequest request)
        {

            if (request == null || HasNullOrEmptyProperties(request))
            {
                return BadRequest(new { message = "El contenido de la petición está incompleto." });
            }

            bool validatedEmail = _validations.ValidEmail(request.Email);

            if (!validatedEmail)
            {
                return BadRequest(new { message = "El email no es válido." });
            }

            bool correctUser = _userService.CorrectUser(request);

            if (!correctUser)
            {
                return StatusCode(500, new { message = "El usuario no es correcto." });
            }

            var token = _userService.GenerateToken(request.Email);

            if (token == null)
            {
                return StatusCode(500, new { message = "El token no ha sido creado." });
            }

            bool stored = _userService.StoreSession(token, _userService.GetUserIdByEmail(request.Email) ?? 0);

            if (!stored)
            {
                return StatusCode(500, new { message = "La sesión no se ha guardado correctamente." });
            }

            return Ok(new { token = token });
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

        [HttpPost("recover-password")]
        public IActionResult RecoverPassword([FromBody] string email)
        {
            bool validatedEmail = _validations.ValidEmail(email);

            if (!validatedEmail)
            {
                return BadRequest(new { message = "El email no es válido." });
            }

            if (!_userService.SendRecoveryCode(email))
            {
                return NotFound(new { message = "El correo no está registrado." });
            }

            return Ok(new { message = "Se ha enviado un correo con las instrucciones." });
        }

        [HttpPost("verifty-recover-password")]
        public IActionResult VerifyRecoverPassword([FromBody] VerifyRecoverPasswordRequest request)
        {
            bool validatedEmail = _validations.ValidEmail(request.Email);

            if (!validatedEmail)
            {
                return BadRequest(new { message = "El email no es válido." });
            }

            if (!_userService.VerifyRecoveryCode(request))
            {
                return NotFound(new { message = "El codigo no es correcto." });
            }

            return Ok(new { message = "El codigo es correcto." });
        }

        [HttpPatch("reset-password")]
        public IActionResult ResetPassword([FromBody] ResetPasswordRequest request)
        {
            bool validatedEmail = _validations.ValidEmail(request.Email);

            if (!validatedEmail)
            {
                return BadRequest(new { message = "El email no es válido." });
            }

            if (!_userService.ResetPassword(request))
            {
                return NotFound(new { message = "La contraseña no se ha podido cambiar correctamente." });
            }

            return Ok(new { message = "La contraseña se ha cambiado correctamente." });
        }

        [HttpPost("convert")]
        public IActionResult Convert([FromBody] string FileName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(FileName))
                    return BadRequest(new { error = "El nombre del archivo no puede ser vacío." });

                string inputPath = Path.Combine(inputFolder, FileName);
                string outputFileName = Path.GetFileNameWithoutExtension(FileName) + ".mp4";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                if (!File.Exists(inputPath))
                    return BadRequest(new { error = "No se encontró el archivo de entrada: " + inputPath });

                if (!Directory.Exists(outputFolder))
                    Directory.CreateDirectory(outputFolder);

                // Usamos la clase correcta FFmpegConverter
                FFmpegConverter ffmpegConverter = new FFmpegConverter();
                ffmpegConverter.Convert(inputPath, outputPath);

                return Ok(new
                {
                    message = "Conversión exitosa",
                    outputFile = outputFileName,
                    outputPath = outputPath
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        private bool HasNullOrEmptyProperties(object obj)
        {
            return obj.GetType().GetProperties().Any(p => p.GetValue(obj) == null || (p.PropertyType == typeof(string) && string.IsNullOrWhiteSpace(p.GetValue(obj) as string)));
        }
    }
}
