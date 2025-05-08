using Clinica.Models;
using DavxeShop.Models;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace DavxeShop.Library.Services.Interfaces
{
    public interface IUserService
    {
        Usuarios LogIn(LoginRequest loginRequest);
        bool LogOut(string request);
    }
}
