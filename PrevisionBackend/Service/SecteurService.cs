using PrevisionBackend.DTO;
using PrevisionBackend.Models;
using PrevisionBackend.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrevisionBackend.Services
{
    public class SecteurService
    {
        private readonly SecteurRepository _secteurRepository;

        public SecteurService(SecteurRepository secteurRepository)
        {
            _secteurRepository = secteurRepository;
        }

        /// <summary>
        /// Récupère tous les Secteurs et les mappe en DTOs de lecture.
        /// </summary>
        /// <returns>Une liste de SecteurReadDto.</returns>
        public async Task<IEnumerable<SecteurReadDto>> GetAllSecteursAsync()
        {
            var secteurs = await _secteurRepository.GetAllAsync();
            return secteurs.Select(s => MapToSecteurReadDto(s)).ToList();
        }

        public async Task<IEnumerable<SecteurReadDto>> GetActiveSecteurByFermeId(string fermeId)
        {
            List<Secteur> secteurs = await _secteurRepository.GetActiveSecteurByFermeId(fermeId);
            return secteurs.Select(s => MapToSecteurReadDto(s)).ToList();
        }

        // --- Mapper Functions ---

        /// <summary>
        /// Mappe un objet Secteur (modèle de base de données) à un SecteurReadDto.
        /// </summary>
        /// <param name="secteur">L'objet Secteur à mapper.</param>
        /// <returns>Un SecteurReadDto.</returns>
        private SecteurReadDto MapToSecteurReadDto(Secteur secteur)
        {
            if (secteur == null) return null;

            return new SecteurReadDto
            {
                Code = secteur.Code,
                Designation = secteur.Designation,
                Superficie = secteur.Superficie
            };
        }
    }
}
