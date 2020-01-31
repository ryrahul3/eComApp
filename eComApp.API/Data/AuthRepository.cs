using System.Threading.Tasks;
using eComApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace eComApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == username.ToLower() && x.Password == password);
            if(user == null)
             return null;
            
            return user;
        }

        public async Task<bool> UserExists(string username)
        {
            if(await _context.Users.AnyAsync(x => x.UserName == username))
             return true;
           
           return false;
        }
    }
}