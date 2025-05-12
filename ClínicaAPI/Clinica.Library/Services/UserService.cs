using Clinica.Models;
using DavxeShop.Library.Services.Interfaces;
using DavxeShop.Models;
using DavxeShop.Persistance.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DavxeShop.Library.Services
{
    public class UserService : IUserService
    {
        private readonly IDavxeShopDboHelper _davxeShopDboHelper;

        public UserService(IDavxeShopDboHelper davxeShopDboHelper)
        {
            _davxeShopDboHelper = davxeShopDboHelper;
        }

        public Usuarios LogIn(LoginRequest loginRequest)
        {
            return _davxeShopDboHelper.LogIn(loginRequest);
        }

        public bool LogOut(string token)
        {
            return _davxeShopDboHelper.LogOut(token);
        }

        public bool SubirImagen(int id, IFormFile imagen)
        {
            if (imagen == null || imagen.Length == 0)
                return false;

            using var memoryStream = new MemoryStream();
            imagen.CopyTo(memoryStream);
            var imagenBytes = memoryStream.ToArray();
            var imagenBase64 = Convert.ToBase64String(imagenBytes);

            return _davxeShopDboHelper.GuardarImagen(id, imagenBase64);
        }

        public string ObtenerImagen(int id)
        {
            return _davxeShopDboHelper.ObtenerImagen(id);
        }

        public List<object> ObtenerAllUsuarios()
        {
            return _davxeShopDboHelper.ObtenerAllUsuarios();
        }
        public List<object> ObtenerAllPacientes()
        {
            return _davxeShopDboHelper.ObtenerAllPacientes();
        }

        public Object UsuarioPorId(int id)
        {
            return _davxeShopDboHelper.UsuarioPorId(id);
        }

        public bool CambiarDatosUsuario(User usuario)
        {
            return _davxeShopDboHelper.CambiarDatosUsuario(usuario);
        }

        public bool EliminarUsuario(int id)
        {
            return _davxeShopDboHelper.EliminarUsuario(id);
        }

        public bool CrearUsuario(RegisterRequest user)
        {
            return _davxeShopDboHelper.CrearUsuario(user);
        }

        public bool CrearPaciente(AltaPacienteRequest paciente)
        {
            return _davxeShopDboHelper.CrearPaciente(paciente);
        }
    }
}
