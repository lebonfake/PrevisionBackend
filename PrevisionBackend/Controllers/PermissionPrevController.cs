using Microsoft.AspNetCore.Mvc;
using PrevisionBackend.DTO;

using PrevisionBackend.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrevisionBackend.Controllers
{
    [ApiController]
    [Route("api/permissionprev")] // Ex: /api/permissionprev
    public class PermissionPrevController : ControllerBase
    {
        private readonly PermissionPrevService _permissionPrevService; // Concrete class

        public PermissionPrevController(PermissionPrevService permissionPrevService)
        {
            _permissionPrevService = permissionPrevService;
        }

        /// <summary>
        /// Récupère toutes les permissions.
        /// </summary>
        /// <returns>Une liste de PermissionPrevReadDto.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermissionPrevReadDto>>> GetAllPermissions()
        {
            var permissions = await _permissionPrevService.GetAllPermissionsAsync();

            // It's generally better to return an empty list (200 OK) rather than 404 for GetAll
            if (permissions == null || !permissions.Any())
            {
                return Ok(new List<PermissionPrevReadDto>());
            }

            return Ok(permissions);
        }
    }
}
