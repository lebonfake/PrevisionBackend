using PrevisionBackend.Data;
using PrevisionBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrevisionBackend.Repositories
{
    public class FermeRepository
    {
        private readonly ApplicationDbContext _context;

        public FermeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupère toutes les Fermes qui ne sont PAS associées à un Flux spécifique.
        /// </summary>
        /// <param name="fluxId">L'ID du Flux à exclure.</param>
        /// <returns>Une collection de Fermes.</returns>
        public async Task<IEnumerable<Ferme>> GetFermesWithoutFluxIdAsync(int fluxId)
        {
            // La logique est la suivante :
            // 1. Inclure les fermes où FluxId est NULL (elles n'ont pas de flux associé).
            // 2. Inclure les fermes où FluxId existe mais n'est PAS égal au fluxId donné.
            // Ce code est correct à condition que 'f.FluxId' soit bien de type 'int?' (nullable).
            return await _context.Fermes
                                 .Where(f => !f.FluxId.HasValue || f.FluxId.Value != fluxId)
                                 .ToListAsync();
        }

        public async Task AffectFermeWithFlux(string fermeId, Flux flux)
        {
            var ferme = await _context.Fermes.Where(f => f.CodFerm == fermeId).FirstOrDefaultAsync();

            if (ferme == null)
            {
                throw new InvalidOperationException($"Ferme with ID {fermeId} not found.");
            }

            // Assigner la propriété de navigation.
            // EF Core s'occupera de la clé étrangère (FluxId) lors du SaveChanges.
            ferme.Flux = flux;

            // IMPORTANT : SaveChangesAsync() N'EST PAS appelé ici.
            // Il sera appelé une seule fois au niveau du service après toutes les affectations.
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
