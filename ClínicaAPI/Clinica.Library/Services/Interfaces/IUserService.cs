using Clinica.Models;
using DavxeShop.Models;
using Microsoft.AspNetCore.Http;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace DavxeShop.Library.Services.Interfaces
{
    public interface IUserService
    {
        Usuarios LogIn(LoginRequest loginRequest);
        bool LogOut(string request);
        bool SubirImagen(int id, IFormFile imagen);
        string ObtenerImagen(int id);
        List<object> ObtenerAllUsuarios();
        Object UsuarioPorId(int id);
        bool CambiarDatosUsuario(User usuario);
        bool EliminarUsuario(int id);
        bool CrearUsuario(RegisterRequest user);
    }
}
