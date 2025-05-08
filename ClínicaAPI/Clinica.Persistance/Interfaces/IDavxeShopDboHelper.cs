using Clinica.Models;
using DavxeShop.Models;

namespace DavxeShop.Persistance.Interfaces
{
    public interface IDavxeShopDboHelper
    {
        Usuarios LogIn(LoginRequest loginRequest);
        bool LogOut(string token);
    }
}
