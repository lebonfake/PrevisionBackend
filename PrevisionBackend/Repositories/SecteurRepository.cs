using PrevisionBackend.Data;
using PrevisionBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrevisionBackend.Repositories
{
    public class SecteurRepository
    {
        private readonly ApplicationDbContext _context;

        public SecteurRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupère un Secteur par son code (ID).
        /// </summary>
        /// <param name="id">Le code (ID) du Secteur.</param>
        /// <returns>Le Secteur trouvé ou null.</returns>
        public async Task<Secteur> GetByIdAsync(int id)
        {
            return await _context.Secteurs.FirstOrDefaultAsync(s => s.Code == id);
        }
        public async Task<List<Secteur>> GetActiveSecteurByFermeId(string fermeId) {

            var secteurs =await _context.Assolements.Where(a => a.FermeCod == fermeId && a.IsActive)
                                                    .Select(a => a.Secteur)
                                                    .Distinct() // Assurez-vous que chaque secteur est unique
                                                    .ToListAsync();
            return secteurs;


        }

        /// <summary>
        /// Récupère tous les Secteurs de la base de données.
        /// </summary>
        /// <returns>Une collection de tous les Secteurs.</returns>
        public async Task<IEnumerable<Secteur>> GetAllAsync()
        {
            return await _context.Secteurs.ToListAsync();
        }

        /// <summary>
        /// Ajoute un nouveau Secteur à la base de données.
        /// </summary>
        /// <param name="secteur">L'objet Secteur à ajouter.</param>
        public async Task AddAsync(Secteur secteur)
        {
            _context.Secteurs.Add(secteur);
            await _context.SaveChangesAsync();
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
