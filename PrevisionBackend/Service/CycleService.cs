using PrevisionBackend.DTO;

using PrevisionBackend.Models;
using PrevisionBackend.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrevisionBackend.Services
{
    public class CycleService
    {
        private readonly CycleRepository _cycleRepository;

        public CycleService(CycleRepository cycleRepository)
        {
            _cycleRepository = cycleRepository;
        }

        /// <summary>
        /// Récupère une liste de Cycles distincts et actifs associés à une ferme spécifique.
        /// </summary>
        /// <param name="fermeId">L'ID de la ferme.</param>
        /// <returns>Une liste de CycleReadDto.</returns>
        public async Task<IEnumerable<CycleReadDto>> GetActiveCycleByFermeId(string fermeId)
        {
            List<Cycle> cycles = await _cycleRepository.GetActiveCycleByFermeId(fermeId);
            return cycles.Select(c => MapToCycleReadDto(c)).ToList();
        }

        /// <summary>
        /// Récupère tous les Cycles et les mappe en DTOs de lecture.
        /// </summary>
        /// <returns>Une liste de CycleReadDto.</returns>
        public async Task<IEnumerable<CycleReadDto>> GetAllCyclesAsync()
        {
            var cycles = await _cycleRepository.GetAllAsync();
            return cycles.Select(c => MapToCycleReadDto(c)).ToList();
        }

        // --- Mapper Functions ---

        /// <summary>
        /// Mappe un objet Cycle (modèle de base de données) à un CycleReadDto.
        /// </summary>
        /// <param name="cycle">L'objet Cycle à mapper.</param>
        /// <returns>Un CycleReadDto.</returns>
        private CycleReadDto MapToCycleReadDto(Cycle cycle)
        {
            if (cycle == null) return null;

            return new CycleReadDto
            {
                CodeCycle = cycle.CodeCycle,
                Designation = cycle.Designation
            };
        }
    }
}
