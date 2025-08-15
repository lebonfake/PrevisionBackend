using Microsoft.AspNetCore.Mvc;
using PrevisionBackend.DTO;
using PrevisionBackend.Services;
using System.Collections.Generic;
using System.Linq; // For .Any()
using System.Threading.Tasks;

namespace PrevisionBackend.Controllers
{
    [ApiController]
    [Route("api/secteurs")] // Ex: /api/secteurs
    public class SecteursController : ControllerBase
    {
        private readonly SecteurService _secteurService;

        public SecteursController(SecteurService secteurService)
        {
            _secteurService = secteurService;
        }

        /// <summary>
        /// Récupère tous les Secteurs disponibles.
        /// </summary>
        /// <returns>Une liste de SecteurReadDto.</returns>
        [HttpGet] // Route for GET /api/secteurs
        public async Task<ActionResult<IEnumerable<SecteurReadDto>>> GetAllSecteurs()
        {
            var secteurs = await _secteurService.GetAllSecteursAsync();

            if (secteurs == null || !secteurs.Any())
            {
                return Ok(new List<SecteurReadDto>()); // Return an empty list if no sectors found
            }

            return Ok(secteurs); // Return 200 OK with the list of sectors
        }

        [HttpGet("get-by-farmId/{fermeId}")]
        public async Task<ActionResult<IEnumerable<SecteurReadDto>>> GetActiveSecteurByFermId(string fermeId)
        {
            var secteurs = await _secteurService.GetActiveSecteurByFermeId(fermeId);
            if (secteurs == null || !secteurs.Any())
            {
                return Ok(new List<SecteurReadDto>()); // Return an empty list if no sectors found
            }
            return Ok(secteurs);
        }


    }
}
