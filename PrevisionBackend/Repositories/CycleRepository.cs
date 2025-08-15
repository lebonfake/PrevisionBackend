using PrevisionBackend.Data;
using PrevisionBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrevisionBackend.Repositories
{
    public class CycleRepository
    {
        private readonly ApplicationDbContext _context;

        public CycleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupère un Cycle par son code (ID).
        /// </summary>
        /// <param name="id">Le code (ID) du Cycle.</param>
        /// <returns>Le Cycle trouvé ou null.</returns>
        public async Task<Cycle> GetByIdAsync(int id)
        {
            return await _context.Cycles.FirstOrDefaultAsync(c => c.CodeCycle == id);
        }

        /// <summary>
        /// Récupère une liste de Cycles distincts associés aux Assolements actifs d'une ferme.
        /// </summary>
        /// <param name="fermeId">L'ID de la ferme.</param>
        /// <returns>Une liste de Cycles.</returns>
        public async Task<List<Cycle>> GetActiveCycleByFermeId(string fermeId)
        {
            return await _context.Assolements
                                 .Where(a => a.FermeCod == fermeId && a.IsActive) // Filtre par ferme et assolements actifs
                                 .Select(a => a.Cycle) // Sélectionne l'objet Cycle associé
                                 .Distinct() // Assure que seuls les cycles distincts sont retournés
                                 .ToListAsync();
        }

        /// <summary>
        /// Récupère tous les Cycles de la base de données.
        /// </summary>
        /// <returns>Une collection de tous les Cycles.</returns>
        public async Task<IEnumerable<Cycle>> GetAllAsync()
        {
            return await _context.Cycles.ToListAsync();
        }

        /// <summary>
        /// Sauvegarde tous les changements en attente dans la base de données.
        /// Cette méthode est appelée par la couche Service pour gérer les transactions.
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
