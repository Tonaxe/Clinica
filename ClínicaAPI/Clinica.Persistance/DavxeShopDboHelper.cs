using Azure.Core;
using Clinica.Models;
using DavxeShop.Models;
using DavxeShop.Persistance.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace DavxeShop.Persistance
{
    public class DavxeShopDboHelper : IDavxeShopDboHelper
    {
        private readonly DavxeShopContext _context;

        public DavxeShopDboHelper(DavxeShopContext context)
        {
            _context = context;
        }
        public Usuarios LogIn(LoginRequest loginRequest)
        {
            return _context.Usuarios.FirstOrDefault(x => x.email == loginRequest.Email && x.contrasena == loginRequest.Password);
        }

        public bool LogOut(string token) 
        {
            var user = _context.Sessions.FirstOrDefault(x => x.Token == token);
            if (user == null) 
                return false;

            user.Ended = DateTime.Now;
            _context.SaveChanges();

            return true;
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
                    p.responsable_id
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
            try
            {
                var nuevoUsuario = new Usuarios
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
                    ? _context.Responsables.FirstOrDefault(x => x.nombre == paciente.responsable_nombre && x.apellido == paciente.responsable_apellido && x.email == paciente.responsable_email)?.id
                    : 0;
                var nuevoPaciente = new Pacientes
                {
                    nombre = paciente.nombre,
                    apellido = paciente.apellido,
                    email = paciente.email,
                    telefono = paciente.telefono,
                    fecha_nacimiento = paciente.fecha_nacimiento,
                    tipo_pago = paciente.tipo_pago,
                    responsable_id = responsable,
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
    }
}
