using Clinica.Models;
using Clinica.Models.dbModels;
using DavxeShop.Persistance.Interfaces;

namespace DavxeShop.Persistance
{
    public class DavxeShopDboHelper : IDavxeShopDboHelper
    {
        private readonly DavxeShopContext _context;

        public DavxeShopDboHelper(DavxeShopContext context)
        {
            _context = context;
        }
        public Usuario LogIn(LoginRequest loginRequest)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email == loginRequest.Email && x.Contrasena == loginRequest.Password);
        }

        public bool GuardarImagen(int id, string imagenBase64)
        {
            var user = _context.Usuarios.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return false;
            }

            user.Imagen = imagenBase64;
            _context.SaveChanges();

            return true;
        }

        public string ObtenerImagen(int id)
        {
            var user = _context.Usuarios.FirstOrDefault(x => x.Id == id);

            if (user == null || user.Imagen == null)
            {
                return null;
            }

            return user.Imagen;
        }

        public List<object> ObtenerAllUsuarios()
        {
            var usuarios = _context.Usuarios
                .Select(u => new
                {
                    u.Id,
                    u.Nombre,
                    u.Apellido,
                    u.Email,
                    u.Rol,
                    u.Imagen
                })
                .ToList<object>();

            return usuarios;
        }
        public List<object> ObtenerAllPacientes()
        {
            var pacientes = _context.Pacientes
                .Select(p => new
                {
                    p.Id,
                    p.Nombre,
                    p.Apellido,
                    p.Email,
                    p.Telefono,
                    p.FechaNacimiento,
                    p.TipoPago,
                    p.ResponsableId,
                    p.Imagen,
                })
                .ToList<object>();

            return pacientes;
        }


        public Object UsuarioPorId(int id)
        {
            var usuario = _context.Usuarios.Where(x => x.Id == id)
                .Select(u => new
                {
                    u.Id,
                    u.Nombre,
                    u.Apellido,
                    u.Email,
                    u.Rol,
                    u.Imagen
                })
                .ToList<object>();

            return usuario;
        }

        public bool CambiarDatosUsuario(User usuario)
        {
            var user = _context.Usuarios.FirstOrDefault(x => x.Id == usuario.id);

            if (user == null)
            {
                return false;
            }

            user.Nombre = usuario.nombre;
            user.Apellido = usuario.apellido;
            user.Email = usuario.email;
            user.Imagen = usuario.Imagen;
            user.Rol = usuario.rol;
            _context.SaveChanges();

            return true;
        }

        public bool EliminarUsuario(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
                return false;

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return true;
        }

        public bool CrearUsuario(RegisterRequest user)
        {
            try
            {
                var nuevoUsuario = new Clinica.Models.dbModels.Usuario
                {
                    Nombre = user.nombre,
                    Apellido = user.apellido,
                    Email = user.email,
                    Contrasena = user.contrasena,
                    Rol = user.rol,
                    Imagen = user.Imagen ?? ""
                };

                _context.Usuarios.Add(nuevoUsuario);

                if (user.rol == "admin")
                {

                }
                else if (user.rol == "odontologo")
                {

                }

                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool CrearPaciente(AltaPacienteRequest paciente)
        {
            try
            {
                var edad = DateTime.Now.Year - paciente.fecha_nacimiento.Year;
                if (DateTime.Now < paciente.fecha_nacimiento.AddYears(edad)) edad--;

                var responsable = edad < 18
                    ? _context.Responsables.FirstOrDefault(x => x.Nombre == paciente.responsable_nombre && x.Apellido == paciente.responsable_apellido && x.Email == paciente.responsable_email)?.Id
                    : 0;
                var nuevoPaciente = new Clinica.Models.dbModels.Paciente
                {
                    Nombre = paciente.nombre,
                    Apellido = paciente.apellido,
                    Email = paciente.email,
                    Telefono = paciente.telefono,
                    FechaNacimiento = paciente.fecha_nacimiento,
                    TipoPago = paciente.tipo_pago,
                    ResponsableId = responsable,
                    Imagen = paciente.imagen,
                };

                _context.Pacientes.Add(nuevoPaciente);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EliminarPaciente(int id)
        {
            var paciente = _context.Pacientes.Find(id);
            if (paciente == null)
                return false;

            _context.Pacientes.Remove(paciente);
            _context.SaveChanges();

            return true;
        }

        public Object PacientePorId(int id)
        {
            var paciente = (from p in _context.Pacientes
                            join r in _context.Responsables on p.ResponsableId equals r.Id
                            where p.Id == id
                            select new
                            {
                                p.Id,
                                p.Nombre,
                                p.Apellido,
                                p.Email,
                                p.FechaNacimiento,
                                p.Telefono,
                                p.TipoPago,
                                responsable_nombre = r.Nombre,
                                responsable_apellido = r.Apellido,
                                responsable_email = r.Email,
                                p.Imagen
                            }).ToList<object>();

            return paciente;
        }


        public bool CambiarDatosPaciente(EditarPaciente pacientes)
        {
            var edad = DateTime.Now.Year - pacientes.fecha_nacimiento.Year;
            if (DateTime.Now < pacientes.fecha_nacimiento.AddYears(edad)) edad--;

            var responsable = edad < 18
                ? _context.Responsables.FirstOrDefault(x => x.Nombre == pacientes.responsable_nombre && x.Apellido == pacientes.responsable_apellido && x.Email == pacientes.responsable_email)?.Id
                : 0;

            var user = _context.Pacientes.FirstOrDefault(x => x.Id == pacientes.id);

            if (user == null)
            {
                return false;
            }

            user.Nombre = pacientes.nombre;
            user.Apellido = pacientes.apellido;
            user.Email = pacientes.email;
            user.FechaNacimiento = pacientes.fecha_nacimiento;
            user.Telefono = pacientes.email;
            user.TipoPago = pacientes.email;
            user.ResponsableId = responsable;
            user.Imagen = pacientes.imagen;
            _context.SaveChanges();

            return true;
        }
    }
}
