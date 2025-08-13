using PrevisionBackend.Models;
using PrevisionBackend.Data;
using Microsoft.EntityFrameworkCore;


namespace PrevisionBackend.Repositories
{
    public class UserRepository
    {
        ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Méthode pour obtenir tous les utilisateurs
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        // Méthode pour obtenir un utilisateur par son ID
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Profile) // Inclure le profil associé
                .FirstOrDefaultAsync(u => u.UserID == id);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .Include(u => u.Profile) // Inclure le profil associé
                .FirstOrDefaultAsync(u => u.Username == username);
        }
    }

}
