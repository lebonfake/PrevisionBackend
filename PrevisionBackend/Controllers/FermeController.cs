using Microsoft.AspNetCore.Mvc;
using PrevisionBackend.DTO;
using PrevisionBackend.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrevisionBackend.Controllers
{
    [ApiController]
    [Route("api/fermes")] // Ex: /api/fermes
    public class FermesController : ControllerBase
    {
        private readonly FermeService _fermeService;

        public FermesController(FermeService fermeService)
        {
            _fermeService = fermeService;
        }

        /// <summary>
        /// Récupère toutes les Fermes qui ne sont PAS associées à un Flux spécifique.
        /// </summary>
        /// <param name="fluxId">L'ID du Flux à exclure.</param>
        /// <returns>Une liste de FermeReadDto.</returns>
        [HttpGet("without-flux/{fluxId}")] // Ex: GET /api/fermes/without-flux/1
        public async Task<ActionResult<IEnumerable<FermeReadDto>>> GetFermesWithoutFluxId(int fluxId)
        {
            var fermes = await _fermeService.GetFermesWithoutFluxIdAsync(fluxId);

            if (fermes == null || !fermes.Any())
            {
                return Ok(new List<FermeReadDto>()); // Retourne une liste vide si aucune ferme trouvée
            }

            return Ok(fermes); // Retourne 200 OK avec la liste des fermes
        }

        [HttpGet("without-system/{systemId}")] // Ex: GET /api/fermes/without-flux/1
        public async Task<ActionResult<IEnumerable<FermeReadDto>>> GetFermesWithoutSystemId(int systemId)
        {
            var fermes = await _fermeService.GetFermesWithoutSystemIdAsync(systemId);

            if (fermes == null || !fermes.Any())
            {
                return Ok(new List<FermeReadDto>()); // Retourne une liste vide si aucune ferme trouvée
            }

            return Ok(fermes); // Retourne 200 OK avec la liste des fermes
        }

        [HttpGet("getByUser/{userId}")]
        public async Task<ActionResult<IEnumerable<FermeReadDto>>> GetFermesByUserId(int userId)
        {
            return await _fermeService.GetFermesByUserId(userId);
        }



        //post
        [HttpPost("affecter-fermes")]
        public async Task<IActionResult> AffectFermesWithFlux([FromBody] AffectFermeRequestDto request)
        {
            Console.WriteLine(request.FluxId);
            Console.WriteLine(request.FermeId[0]);

            try
            {
                // Appelle la méthode du service pour affecter les fermes au flux
                await _fermeService.AffectFerme(request.FermeId, request.FluxId);
                return Ok(); // Retourne 200 OK en cas de succès
            }
            catch (InvalidOperationException ex) // Capture les exceptions levées par le service (ex: Flux non trouvé, Ferme non trouvée)
            {
                return NotFound(ex.Message); // Retourne 404 Not Found si l'entité liée n'existe pas
            }
            catch (Exception ex)
            {
                // Capturer toute autre exception inattendue pour débogage et retour 500
                // Vous devriez logger 'ex' ici
                return StatusCode(500, "Une erreur interne est survenue lors de l'affectation du flux aux fermes.");
            }
        }

        [HttpPost("affecter-fermes-systemver")]
        public async Task<IActionResult> AffectFermesWithFlux([FromBody] AffectFermeVesrionDto request)
        {
           

            try
            {
                // Appelle la méthode du service pour affecter les fermes au flux
                await _fermeService.AffectFermeWithVersion(request.FermeId, request.SystemId);
                return Ok(); // Retourne 200 OK en cas de succès
            }
            catch (InvalidOperationException ex) // Capture les exceptions levées par le service (ex: Flux non trouvé, Ferme non trouvée)
            {
                return NotFound(ex.Message); // Retourne 404 Not Found si l'entité liée n'existe pas
            }
            catch (Exception ex)
            {
                // Capturer toute autre exception inattendue pour débogage et retour 500
                // Vous devriez logger 'ex' ici
                return StatusCode(500, "Une erreur interne est survenue lors de l'affectation du flux aux fermes.");
            }
        }
    }
}
