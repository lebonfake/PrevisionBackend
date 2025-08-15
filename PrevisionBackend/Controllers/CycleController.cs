using Microsoft.AspNetCore.Mvc;
using PrevisionBackend.DTO;

using PrevisionBackend.Services;
using System.Collections.Generic;
using System.Linq; // For .Any()
using System.Threading.Tasks;

namespace PrevisionBackend.Controllers
{
    [ApiController]
    [Route("api/cycles")] // Ex: /api/cycles
    public class CyclesController : ControllerBase
    {
        private readonly CycleService _cycleService;

        public CyclesController(CycleService cycleService)
        {
            _cycleService = cycleService;
        }

        /// <summary>
        /// Récupère tous les Cycles disponibles.
        /// </summary>
        /// <returns>Une liste de CycleReadDto.</returns>
        [HttpGet] // Route for GET /api/cycles
        public async Task<ActionResult<IEnumerable<CycleReadDto>>> GetAllCycles()
        {
            var cycles = await _cycleService.GetAllCyclesAsync();

            if (cycles == null || !cycles.Any())
            {
                return Ok(new List<CycleReadDto>()); // Return an empty list if no cycles found
            }

            return Ok(cycles); // Return 200 OK with the list of cycles
        }


        /// <summary>
        /// Récupère une liste de Cycles distincts et actifs associés aux assolements d'une ferme donnée.
        /// </summary>
        /// <param name="fermeId">L'ID de la ferme.</param>
        /// <returns>Une liste de CycleReadDto.</returns>
        [HttpGet("get-by-farmId/{fermeId}")] // Ex: GET /api/cycles/get-by-farmId/FERME001
        public async Task<ActionResult<IEnumerable<CycleReadDto>>> GetActiveCycleByFermeId(string fermeId)
        {
            var cycles = await _cycleService.GetActiveCycleByFermeId(fermeId);
            if (cycles == null || !cycles.Any())
            {
                return Ok(new List<CycleReadDto>()); // Return an empty list if no cycles found
            }
            return Ok(cycles);
        }
    }
}
