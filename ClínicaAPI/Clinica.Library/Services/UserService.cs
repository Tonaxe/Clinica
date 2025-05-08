using Clinica.Models;
using DavxeShop.Library.Services.Interfaces;
using DavxeShop.Models;
using DavxeShop.Persistance.Interfaces;

namespace DavxeShop.Library.Services
{
    public class UserService : IUserService
    {
        private readonly IDavxeShopDboHelper _davxeShopDboHelper;

        public UserService(IDavxeShopDboHelper davxeShopDboHelper)
        {
            _davxeShopDboHelper = davxeShopDboHelper;
        }

        public Usuarios LogIn(LoginRequest loginRequest)
        {
            return _davxeShopDboHelper.LogIn(loginRequest);
        }

        public bool LogOut(string token)
        {
            return _davxeShopDboHelper.LogOut(token);
        }
    }
}
