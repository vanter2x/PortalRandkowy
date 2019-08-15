using System.Threading.Tasks;
using PortalRandkowy.API.Models;

namespace PortalRandkowy.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Login(string name, string password);
         Task<User> Register(User user, string password);
         Task<bool> UserExist(string username);
    }
}