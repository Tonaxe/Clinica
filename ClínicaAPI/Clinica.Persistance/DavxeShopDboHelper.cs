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
    }
}
