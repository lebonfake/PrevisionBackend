using PrevisionBackend.DTO;
using PrevisionBackend.Models;
using PrevisionBackend.Repositories;
using System.Collections.Generic;
using System.Linq; // Needed for .Select()
using System.Threading.Tasks;

namespace PrevisionBackend.Services
{
    public class PermissionPrevService
    {
        private readonly PermissionPrevRepository _permissionPrevRepository; // Concrete class

        public PermissionPrevService(PermissionPrevRepository permissionPrevRepository)
        {
            _permissionPrevRepository = permissionPrevRepository;
        }

        /// <summary>
        /// Récupère toutes les permissions et les mappe en DTOs de lecture.
        /// </summary>
        /// <returns>Une liste de PermissionPrevReadDto.</returns>
        public async Task<List<PermissionPrevReadDto>> GetAllPermissionsAsync()
        {
            var permissions = await _permissionPrevRepository.GetAllAsync();
            return permissions.Select(p => MapToPermissionPrevReadDto(p)).ToList();
        }

        /// <summary>
        /// Mappe un objet PermissionPrev (modèle de base de données) à un PermissionPrevReadDto.
        /// </summary>
        /// <param name="permissionPrev">L'objet PermissionPrev à mapper.</param>
        /// <returns>Un PermissionPrevReadDto.</returns>
        private PermissionPrevReadDto MapToPermissionPrevReadDto(PermissionPrev permissionPrev)
        {
            if (permissionPrev == null) return null;

            return new PermissionPrevReadDto
            {
                Id = permissionPrev.Id,
                // Convertir l'enum PermissionType en string pour l'affichage
                Permissions = permissionPrev.Permissions.ToString()
            };
        }
    }
}
