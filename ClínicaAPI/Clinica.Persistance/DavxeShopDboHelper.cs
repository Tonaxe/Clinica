using Azure.Core;
using Clinica.Models;
using DavxeShop.Models;
using DavxeShop.Persistance.Interfaces;
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
    }
}
