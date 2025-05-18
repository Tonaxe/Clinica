using Clinica.Models;
using Clinica.Models.dbModels;
using DavxeShop.Library.Services.Interfaces;
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

        public Usuario LogIn(LoginRequest loginRequest)
        {
            return _davxeShopDboHelper.LogIn(loginRequest);
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

        public bool EliminarPaciente(int id)
        {
            return _davxeShopDboHelper.EliminarPaciente(id);
        }

        public Object PacientePorId(int id)
        {
            return _davxeShopDboHelper.PacientePorId(id);
        }

        public bool CambiarDatosPaciente(EditarPaciente pacientes)
        {
            return _davxeShopDboHelper.CambiarDatosPaciente(pacientes);
        }

        public List<object> ObtenerAllVisitas()
        {
            return _davxeShopDboHelper.ObtenerAllVisitas();
        }
        public bool EliminarVisita(int id)
        {
            return _davxeShopDboHelper.EliminarVisita(id);
        }
        public bool EditarVisita(int id, Visita visita)
        {
            return _davxeShopDboHelper.EditarVisita(id, visita);
        }

        public bool CrearVisita(VisitaRequest visita)
        {
            return _davxeShopDboHelper.CrearVisita( visita);
        }
    }
}
