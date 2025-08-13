using Microsoft.AspNetCore.Mvc;
using PrevisionBackend.DTO;
using PrevisionBackend.Services;
using System.Threading.Tasks;

namespace PrevisionBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Ex: /api/flux
    public class FluxController : ControllerBase
    {
        private readonly FluxService _fluxService;

        public FluxController(FluxService fluxService)
        {
            _fluxService = fluxService;
        }

        /// <summary>
        /// Crée un nouveau Flux avec ses étapes et associations de validateurs/permissions.
        /// </summary>
        /// <param name="fluxDto">Le DTO contenant les données du Flux à créer.</param>
        /// <returns>Le Flux créé.</returns>
        [HttpPost]
        public async Task<ActionResult<FluxReadDto>> CreateFlux([FromBody] FluxCreateDto fluxDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Retourne 400 Bad Request si les données sont invalides
            }

            try
            {
                var createdFlux = await _fluxService.CreateFluxAsync(fluxDto);

                if (createdFlux == null)
                {
                    // Ceci pourrait indiquer un problème de logique métier interne (ex: entités liées non trouvées)
                    return BadRequest("Failed to create Flux. Check related entities (Validateur, PermissionPrev) IDs.");
                }

                // Retourne 201 Created et l'URL de la nouvelle ressource
                return CreatedAtAction(nameof(GetFluxById), new { id = createdFlux.Id }, createdFlux);
            }
            catch (ArgumentException ex) // Capter les exceptions spécifiques levées par le service
            {
                return BadRequest(ex.Message); // Retourne 400 avec le message d'erreur
            }
            catch (Exception ex)
            {
                // Log l'exception pour le débogage
                // logger.LogError(ex, "Error creating Flux.");
                return StatusCode(500, "An internal server error occurred while creating the Flux.");
            }
        }

        // Note: Pour que CreatedAtAction fonctionne, vous avez besoin d'une méthode GetFluxById.
        // Ceci est un placeholder, vous devrez l'implémenter dans le service et le controller.
        [HttpGet("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)] // Cache cette méthode de Swagger si elle n'est pas complètement implémentée
        public ActionResult<FluxReadDto> GetFluxById(int id)
        {
            // Cette méthode est juste un placeholder pour CreatedAtAction.
            // Une implémentation réelle irait chercher le flux via le service.
            return NotFound();
        }

        [HttpGet] // Route for GET /api/flux (no ID)
        public async Task<ActionResult<IEnumerable<FluxReadDto>>> GetAllFlux()
        {
            var fluxList = await _fluxService.GetAllFluxAsync();

            // Il est généralement préférable de renvoyer une liste vide (200 OK) plutôt que 404 pour GetAll
            if (fluxList == null || !fluxList.Any())
            {
                return Ok(new List<FluxReadDto>());
            }

            return Ok(fluxList); // Renvoie 200 OK avec la liste des Flux
        }
    }
}
