using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;
using PrevisionBackend.Data;
using PrevisionBackend.Models;

namespace PrevisionBackend.Repositories
{
    public class ValidateurRepository
    {

        private ApplicationDbContext _context;

        public ValidateurRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Méthode pour obtenir tous les validateurs
        public async Task<List<Validateur>> GetAllValidateursAsync()
        {
            return await _context.Validateurs
                                 .Include(v => v.User) // IMPORTANT : Incluez l'objet User ici pour éviter NRE
                                 .ToListAsync();
        }

        // Méthode pour obtenir un validateur par son ID
        public async Task<Validateur> GetValidateurByIdAsync(int id)
        {
            return await _context.Validateurs
                .Include(v => v.User) // Inclure l'utilisateur associé
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        // Méthode pour ajouter un nouveau validateur
        public async Task<Validateur> AddValidateurAsync(Validateur validateur)
        {
            _context.Validateurs.Add(validateur);
            await _context.SaveChangesAsync();
            return validateur;
        }

        // Méthode pour mettre à jour un validateur existant
        public async Task<Validateur> UpdateValidateurAsync(Validateur validateur)
        {
            _context.Validateurs.Update(validateur);
            await _context.SaveChangesAsync();
            return validateur;
        }
        public async Task<Validateur> GetValidateurByUserIdAsync(int userID)
        {
          

            var validateur =  await _context.Validateurs
                .Include(v => v.User) // Inclure l'utilisateur associé
                .FirstOrDefaultAsync(v => v.User.UserID == userID);
            if(validateur == null)
            {
                return null; // Si aucun validateur n'est trouvé pour l'utilisateur donné
            }
            return validateur; // Retourne le validateur trouvé
        }

        public async Task<bool> DeleteValidatuerByIdAsync(int id)
        {
            // 1. Trouver le validateur à supprimer
            var validateur = await _context.Validateurs.FindAsync(id);

            // 2. Vérifier si le validateur existe
            if (validateur == null)
            {
                return false; // Validateur non trouvé
            }

            // 3. Supprimer le validateur du DbSet
            _context.Validateurs.Remove(validateur);

            // 4. Enregistrer les changements dans la base de données
            await _context.SaveChangesAsync();

            return true; // Validateur supprimé avec succès
        }
    }
}
