using PrevisionBackend.DTO;
using PrevisionBackend.Models;
using PrevisionBackend.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrevisionBackend.Services
{
    public class FermeService
    {
        private readonly FermeRepository _fermeRepository;

        private readonly FluxRepository _fluxRepository;

        public FermeService(FermeRepository fermeRepository,FluxRepository fluxRepository)
        {
            _fermeRepository = fermeRepository;
            _fluxRepository =  fluxRepository;
        }

        /// <summary>
        /// Récupère les Fermes qui ne sont PAS associées à un Flux spécifique et les mappe en DTOs.
        /// </summary>
        /// <param name="fluxId">L'ID du Flux à exclure.</param>
        /// <returns>Une liste de FermeReadDto.</returns>
        public async Task<IEnumerable<FermeReadDto>> GetFermesWithoutFluxIdAsync(int fluxId)
        {
            var fermes = await _fermeRepository.GetFermesWithoutFluxIdAsync(fluxId);
            return fermes.Select(f => MapToFermeReadDto(f)).ToList();
        }


        public async Task AffectFerme(List<string> codeFermes, int fluxId)
        {
            var flux = await _fluxRepository.GetByIdAsync(fluxId);
            if (flux == null)
            {
                throw new InvalidOperationException($"Flux with ID {fluxId} not found.");
            }

            foreach (var codeFerme in codeFermes)
            {
                // Le repository va trouver et affecter le flux à la ferme
                await _fermeRepository.AffectFermeWithFlux(codeFerme, flux);
            }

            // IMPORTANT : SaveChangesAsync est appelé une seule fois ici au niveau du service
            // après toutes les opérations d'affectation pour assurer l'atomicité de la transaction.
            await _fermeRepository.SaveChangesAsync(); // Cette méthode doit être ajoutée au FermeRepository
        }

        /// <summary>
        /// Mappe un objet Ferme (modèle de base de données) à un FermeReadDto.
        /// </summary>
        /// <param name="ferme">L'objet Ferme à mapper.</param>
        /// <returns>Un FermeReadDto.</returns>
        private FermeReadDto MapToFermeReadDto(Ferme ferme)
        {
            if (ferme == null) return null;

            return new FermeReadDto
            {
                Id = ferme.CodFerm,
                Nom = ferme.NomFerm
            };
        }
        
    }
}
