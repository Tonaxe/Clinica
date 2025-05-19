using Clinica.Models;
using Clinica.Models.dbModels;
using Microsoft.AspNetCore.Http;

namespace DavxeShop.Library.Services.Interfaces
{
    public interface IUserService
    {
        Usuario LogIn(LoginRequest loginRequest);
        bool SubirImagen(int id, IFormFile imagen);
        string ObtenerImagen(int id);
        List<object> ObtenerAllUsuarios();
        List<object> ObtenerAllPacientes();
        Object UsuarioPorId(int id);
        bool CambiarDatosUsuario(User usuario);
        bool EliminarUsuario(int id);
        bool CrearUsuario(RegisterRequest user);
        bool CrearPaciente(AltaPacienteRequest paciente);
        bool EliminarPaciente(int id);
        Object PacientePorId(int id);
        bool CambiarDatosPaciente(EditarPaciente pacientes);
        List<object> ObtenerAllVisitas();
        bool EliminarVisita(int id);
        bool EditarVisita(int id, VisitaEditarRequest visitaRequest);
        bool CrearVisita(VisitaRequest visita);
        object? ObtenerVisita(int id);
        List<object> ObtenerAllVisitasByOdontologo(int id);
    }
}
