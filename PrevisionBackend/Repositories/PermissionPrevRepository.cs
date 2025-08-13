using Microsoft.EntityFrameworkCore;
using PrevisionBackend.Data;
using PrevisionBackend.Models;
using System.Threading.Tasks;

namespace PrevisionBackend.Repositories
{
    // Implementation du Repository pour l'entité PermissionPrev
    // Note: L'absence d'interface peut rendre les tests unitaires plus difficiles
    // et réduire la flexibilité pour changer l'implémentation.
    public class PermissionPrevRepository
    {
        private readonly ApplicationDbContext _context;

        public PermissionPrevRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Ajoute une nouvelle PermissionPrev à la base de données.
        /// </summary>
        /// <param name="permissionPrev">L'objet PermissionPrev à ajouter.</param>
        public async Task AddAsync(PermissionPrev permissionPrev)
        {
            _context.PermissionPrevisions.Add(permissionPrev);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Récupère une PermissionPrev par son ID.
        /// </summary>
        /// <param name="id">L'ID de la PermissionPrev à récupérer.</param>
        /// <returns>La PermissionPrev trouvée, ou null si non trouvée.</returns>
        public async Task<PermissionPrev> GetByIdAsync(int id)
        {
            // Nous n'incluons pas de navigation ici car PermissionPrev
            // ne semble pas avoir de propriétés de navigation directes à charger
            // à part la collection inverse que nous n'incluons pas pour GetById.
            return await _context.PermissionPrevisions.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<PermissionPrev>> GetAllAsync()
        {
            return await _context.PermissionPrevisions.ToListAsync();
        }
    }
}
