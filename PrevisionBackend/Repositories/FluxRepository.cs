using Microsoft.EntityFrameworkCore;
using PrevisionBackend.Data;
using PrevisionBackend.Models;
using System.Threading.Tasks;

namespace PrevisionBackend.Repositories
{
   
    // Implémentation du Repository pour l'entité Flux
    public class FluxRepository 
    {
        private readonly ApplicationDbContext _context;

        public FluxRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Ajoute un nouveau Flux et ses entités imbriquées (EtapesFlux, EtapeFluxValidateurPermissions) à la base de données.
        /// </summary>
        /// <param name="flux">L'objet Flux à ajouter.</param>
        public async Task AddAsync(Flux flux)
        {
            _context.Flux.Add(flux);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Récupère un Flux par son ID, incluant ses étapes de flux.
        /// </summary>
        /// <param name="id">L'ID du Flux.</param>
        /// <returns>Le Flux trouvé avec ses étapes, ou null.</returns>
        public async Task<Flux> GetByIdAsync(int id)
        {
            // Incluez les propriétés de navigation nécessaires pour le mappage au DTO de lecture
            return await _context.Flux
                                 .Include(f => f.Etapes)
                                     .ThenInclude(ef => ef.EtapeFluxValidateurPermissions)
                                         .ThenInclude(efvp => efvp.Validateur) // Inclut le validateur dans la jonction
                                             .ThenInclude(v => v.User) // Inclut l'utilisateur du validateur
                                 .Include(f => f.Etapes)
                                     .ThenInclude(ef => ef.EtapeFluxValidateurPermissions)
                                         .ThenInclude(efvp => efvp.PermissionPrev) // Inclut la permission dans la jonction
                                 .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Flux>> GetAllAsync()
        {
            return await _context.Flux
                                 .Include(f => f.Etapes) // Changed Etapes to EtapesFlux
                                     .ThenInclude(ef => ef.EtapeFluxValidateurPermissions)
                                         .ThenInclude(efvp => efvp.Validateur)
                                             .ThenInclude(v => v.User)
                                 .Include(f => f.Etapes) // Changed Etapes to EtapesFlux
                                     .ThenInclude(ef => ef.EtapeFluxValidateurPermissions)
                                         .ThenInclude(efvp => efvp.PermissionPrev)
                                 .ToListAsync();
        }
    }
}
