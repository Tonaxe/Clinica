using Clinica.Models;
using Clinica.Models.dbModels;

namespace DavxeShop.Persistance.Interfaces
{
    public interface IDavxeShopDboHelper
    {
        Usuario LogIn(LoginRequest loginRequest);
        bool GuardarImagen(int id, string imagenBase64);
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
    }
}
