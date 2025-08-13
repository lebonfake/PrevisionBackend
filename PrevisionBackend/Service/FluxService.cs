using PrevisionBackend.DTO;
using PrevisionBackend.Models;
using PrevisionBackend.Repositories;
using System; // For DateTime
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrevisionBackend.Services
{

    // Implémentation du Service pour les Flux
    public class FluxService 
    {
        private readonly FluxRepository _fluxRepository;
        private readonly ValidateurRepository _validateurRepository;
        private readonly PermissionPrevRepository _permissionPrevRepository; // <-- Vous aurez besoin de ce repository

        public FluxService(
            FluxRepository fluxRepository,
            ValidateurRepository validateurRepository,
            PermissionPrevRepository permissionPrevRepository)
        {
            _fluxRepository = fluxRepository;
            _validateurRepository = validateurRepository;
            _permissionPrevRepository = permissionPrevRepository;
        }

        /// <summary>
        /// Crée un nouveau Flux avec ses étapes et les associations validateur/permission.
        /// </summary>
        /// <param name="fluxDto">Le DTO de création du Flux.</param>
        /// <returns>Un FluxReadDto du Flux créé.</returns>
        public async Task<FluxReadDto> CreateFluxAsync(FluxCreateDto fluxDto)
        {
            var flux = new Flux
            {
                Nom = fluxDto.Nom,
                Etapes = new List<EtapeFlux>()
            };

            foreach (var etapeFluxDto in fluxDto.EtapeFluxs)
            {
                var etapeFlux = new EtapeFlux
                {
                    Ordre = etapeFluxDto.Ordre,
                    Nom = etapeFluxDto.Nom,
                    EtapeFluxValidateurPermissions = new List<EtapeFluxValidateurPermission>()
                };

                foreach (var linkDto in etapeFluxDto.EtapeFluxValidateurPermissionLinks)
                {
                    // Valider si Validateur et PermissionPrev existent
                    var validateur = await _validateurRepository.GetValidateurByIdAsync(linkDto.ValidateurId);
                    var permissionPrev = await _permissionPrevRepository.GetByIdAsync(linkDto.PermissionPrevId);

                    if (validateur == null || permissionPrev == null)
                    {
                        // Gérer l'erreur : validateur ou permission non trouvé.
                        // Vous pouvez lever une exception, retourner null, ou une erreur spécifique.
                        // Pour cet exemple, nous allons simplement ignorer cette entrée ou renvoyer null pour le flux.
                        throw new ArgumentException($"Validateur (ID: {linkDto.ValidateurId}) or PermissionPrev (ID: {linkDto.PermissionPrevId}) not found.");
                    }

                    var etapeFluxValidateurPermission = new EtapeFluxValidateurPermission
                    {
                        ValidateurId = linkDto.ValidateurId,
                        Validateur = validateur, // Attacher l'objet pour EF Core
                        PermissionPrevId = linkDto.PermissionPrevId,
                        PermissionPrev = permissionPrev, // Attacher l'objet pour EF Core
                        DateAssigned = DateTime.UtcNow // Ou utilisez une valeur du DTO si fournie
                    };
                    etapeFlux.EtapeFluxValidateurPermissions.Add(etapeFluxValidateurPermission);
                }
                flux.Etapes.Add(etapeFlux);
            }

            await _fluxRepository.AddAsync(flux);

            // Pour s'assurer que les données pour le DTO de retour sont complètes,
            // récupérez le flux fraîchement créé avec toutes ses entités de navigation.
            var createdFlux = await _fluxRepository.GetByIdAsync(flux.Id);
            return MapToFluxReadDto(createdFlux);
        }

        // --- Mapper Functions ---

        /// <summary>
        /// Mappe un objet Flux (modèle de base de données) à un FluxReadDto.
        /// </summary>
        /// <param name="flux">L'objet Flux à mapper.</param>
        /// <returns>Un FluxReadDto.</returns>
        private FluxReadDto MapToFluxReadDto(Flux flux)
        {
            if (flux == null) return null;

            return new FluxReadDto
            {
                Id = flux.Id,
                Nom = flux.Nom, // Assurez-vous que le nom du flux est correctement mappé
                NombreEtapes = flux.Etapes?.Count ?? 0
            };
        }
        // Vous pourriez ajouter d'autres mappers ici si nécessaire pour les DTOs de lecture imbriqués.
        // Par exemple:
        // private EtapeFluxReadDto MapToEtapeFluxReadDto(EtapeFlux etapeFlux) { ... }


        /// <summary>
        /// Récupère tous les Flux et les mappe en DTOs de lecture.
        /// </summary>
        /// <returns>Une liste de FluxReadDto.</returns>
        public async Task<IEnumerable<FluxReadDto>> GetAllFluxAsync()
        {
            var fluxList = await _fluxRepository.GetAllAsync();
            return fluxList.Select(f => MapToFluxReadDto(f)).ToList();
        }


        // --- Mapper Functions ---

        /// <summary>
        /// Mappe un objet Flux (modèle de base de données) à un FluxReadDto.
        /// </summary>
        /// <param name="flux">L'objet Flux à mapper.</param>
        /// <returns>Un FluxReadDto.</returns>
       
    }

}
