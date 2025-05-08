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
    }
}
