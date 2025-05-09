﻿using Clinica.Models;
using DavxeShop.Models;

namespace DavxeShop.Persistance.Interfaces
{
    public interface IDavxeShopDboHelper
    {
        Usuarios LogIn(LoginRequest loginRequest);
        bool LogOut(string token);
        bool GuardarImagen(int id, string imagenBase64);
        string ObtenerImagen(int id);
        List<object> ObtenerAllUsuarios();
        Object UsuarioPorId(int id);
        bool CambiarDatosUsuario(User usuario);
        bool EliminarUsuario(int id);
        bool CrearUsuario(RegisterRequest user);
    }
}
