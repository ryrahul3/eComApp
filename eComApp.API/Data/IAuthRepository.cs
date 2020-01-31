using System.Threading.Tasks;
using eComApp.API.Models;

namespace eComApp.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Login(string username, string password);
         Task<bool> UserExists(string username);
    }
}