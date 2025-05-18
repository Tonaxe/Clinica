using Clinica.Models;
using Clinica.Models.dbModels;
using DavxeShop.Persistance.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            return _context.Usuarios.FirstOrDefault(x => x.email == loginRequest.Email && x.contrasena == loginRequest.Password);
        }

        public bool GuardarImagen(int id, string imagenBase64)
        {
            var user = _context.Usuarios.FirstOrDefault(x => x.id == id);

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
            var user = _context.Usuarios.FirstOrDefault(x => x.id == id);

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
                    u.id,
                    u.nombre,
                    u.apellido,
                    u.email,
                    u.rol,
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
                    p.id,
                    p.nombre,
                    p.apellido,
                    p.email,
                    p.telefono,
                    p.fecha_nacimiento,
                    p.tipo_pago,
                    p.responsable_id,
                    p.Imagen,
                })
                .ToList<object>();

            return pacientes;
        }


        public Object UsuarioPorId(int id)
        {
            var usuario = _context.Usuarios.Where(x => x.id == id)
                .Select(u => new
                {
                    u.id,
                    u.nombre,
                    u.apellido,
                    u.email,
                    u.rol,
                    u.Imagen
                })
                .ToList<object>();

            return usuario;
        }

        public bool CambiarDatosUsuario(User usuario)
        {
            var user = _context.Usuarios.FirstOrDefault(x => x.id == usuario.id);

            if (user == null)
            {
                return false;
            }

            user.nombre = usuario.nombre;
            user.apellido = usuario.apellido;
            user.email = usuario.email;
            user.Imagen = usuario.Imagen;
            user.rol = usuario.rol;
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
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var nuevoUsuario = new Clinica.Models.dbModels.Usuario
                {
                    nombre = user.nombre,
                    apellido = user.apellido,
                    email = user.email,
                    contrasena = user.contrasena,
                    rol = user.rol,
                    Imagen = user.Imagen ?? ""
                };

                _context.Usuarios.Add(nuevoUsuario);
                _context.SaveChanges();

                if (user.rol == "admin")
                {
                    var admin = new Administrativo
                    {
                        usuario_id = nuevoUsuario.id,
                        puesto = "Administrativo"
                    };
                    _context.Administrativos.Add(admin);
                }
                else if (user.rol == "odontologo")
                {
                    var odontologo = new Odontologo
                    {
                        usuario_id = nuevoUsuario.id,
                        especialidad = "Odontologo"
                    };

                    _context.Odontologos.Add(odontologo);
                    _context.SaveChanges();

                    var dias = new[] { "LU", "MA", "MI", "JU", "VI" };
                    var horarios = dias.Select(dia => new Horario
                    {
                        odontologo_id = odontologo.id,
                        dia = dia,
                        hora_inicio = TimeSpan.Parse("08:00"),
                        hora_fin = TimeSpan.Parse("15:00")
                    }).ToList();

                    _context.Horarios.AddRange(horarios);
                }

                _context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
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
                    ? _context.Responsables.FirstOrDefault(x => x.nombre == paciente.responsable_nombre && x.apellido == paciente.responsable_apellido && x.email == paciente.responsable_email)?.id
                    : 0;
                var nuevoPaciente = new Clinica.Models.dbModels.Paciente
                {
                    nombre = paciente.nombre,
                    apellido = paciente.apellido,
                    email = paciente.email,
                    telefono = paciente.telefono,
                    fecha_nacimiento = paciente.fecha_nacimiento,
                    tipo_pago = paciente.tipo_pago,
                    responsable_id = responsable,
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
                            join r in _context.Responsables on p.responsable_id equals r.id
                            where p.id == id
                            select new
                            {
                                p.id,
                                p.nombre,
                                p.apellido,
                                p.email,
                                p.fecha_nacimiento,
                                p.telefono,
                                p.tipo_pago,
                                responsable_nombre = r.nombre,
                                responsable_apellido = r.apellido,
                                responsable_email = r.email,
                                p.Imagen
                            }).ToList<object>();

            return paciente;
        }


        public bool CambiarDatosPaciente(EditarPaciente pacientes)
        {
            var edad = DateTime.Now.Year - pacientes.fecha_nacimiento.Year;
            if (DateTime.Now < pacientes.fecha_nacimiento.AddYears(edad)) edad--;

            var responsable = edad < 18
                ? _context.Responsables.FirstOrDefault(x => x.nombre == pacientes.responsable_nombre && x.apellido == pacientes.responsable_apellido && x.email == pacientes.responsable_email)?.id
                : 0;

            var user = _context.Pacientes.FirstOrDefault(x => x.id == pacientes.id);

            if (user == null)
            {
                return false;
            }

            user.nombre = pacientes.nombre;
            user.apellido = pacientes.apellido;
            user.email = pacientes.email;
            user.fecha_nacimiento = pacientes.fecha_nacimiento;
            user.telefono = pacientes.email;
            user.tipo_pago = pacientes.email;
            user.responsable_id = responsable;
            user.Imagen = pacientes.imagen;
            _context.SaveChanges();

            return true;
        }

        public List<object> ObtenerAllVisitas()
        {
            var visitas = _context.Visitas
                .Include(v => v.Paciente)
                .Include(v => v.Odontologo)
                    .ThenInclude(o => o.Usuario)
                .Select(v => new
                {
                    v.id,
                    v.fecha_hora,
                    v.motivo,
                    v.observaciones,
                    v.tratamiento_prescrito,
                    Paciente = new
                    {
                        v.Paciente.nombre,
                        v.Paciente.apellido
                    },
                    Odontologo = new
                    {
                        v.Odontologo.Usuario.nombre,
                        v.Odontologo.Usuario.apellido
                    }
                })
                .ToList<object>();

            return visitas;
        }
        public bool EliminarVisita(int id)
        {
            var visita = _context.Visitas.Find(id);
            if (visita == null)
                return false;

            _context.Visitas.Remove(visita);
            _context.SaveChanges();

            return true;
        }

        public bool EditarVisita(int id, Visita visitaActualizada)
        {
            try
            {
                var visita = _context.Visitas
                    .Include(v => v.Paciente)
                    .Include(v => v.Odontologo)
                    .FirstOrDefault(v => v.id == id);

                if (visita == null)
                    return false;

                visita.fecha_hora = visitaActualizada.fecha_hora;
                visita.motivo = visitaActualizada.motivo;
                visita.observaciones = visitaActualizada.observaciones;
                visita.tratamiento_prescrito = visitaActualizada.tratamiento_prescrito;
                visita.paciente_id = visitaActualizada.paciente_id;
                visita.odontologo_id = visitaActualizada.odontologo_id;

                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CrearVisita(VisitaRequest visita)
        {
            try
            {
                var pacienteId = _context.Pacientes.FirstOrDefault(x => x.nombre == visita.paciente).id;
                var odontologoId = _context.Odontologos.FirstOrDefault(y => y.usuario_id == _context.Usuarios.FirstOrDefault(x => x.nombre == visita.odontologo).id).id;

                var visitaF = new Visita
                {
                    paciente_id = pacienteId,
                    odontologo_id = odontologoId,
                    fecha_hora = visita.fechaYhora,
                    motivo = visita.motivo,
                    observaciones = visita.observaciones,
                };

                _context.Visitas.Add(visitaF);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
