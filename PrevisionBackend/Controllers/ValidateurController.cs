using Microsoft.AspNetCore.Mvc;
using PrevisionBackend.DTO;
using PrevisionBackend.Service;
using System.Threading.Tasks;

namespace PrevisionBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValidateursController : ControllerBase
    {
        private readonly ValidateurService _validateurService;

        public ValidateursController(ValidateurService validateurService)
        {
            _validateurService = validateurService;
        }

        // POST: api/Validateurs
        [HttpPost]
        public async Task<ActionResult<ValidateurReadDto>> CreateValidateur([FromBody] ValidateurCreateDto validateurDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdValidateur = await _validateurService.AddValidateurAsync(validateurDto);

            if (createdValidateur == null)
            {
                return BadRequest("User not found or other business rule violation.");
            }

            return CreatedAtAction(nameof(GetValidateurById), new { id = createdValidateur.Id }, createdValidateur);
        }

        // GET: api/Validateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ValidateurReadDto>> GetValidateurById(int id)
        {
            var validateur = await _validateurService.GetValidateurByIdAsync(id);

            if (validateur == null)
            {
                return NotFound();
            }

            return Ok(validateur);
        }

        // GET: api/Validateurs (get all)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ValidateurReadDto>>> GetAllValidateurs()
        {
            var validateurs = await _validateurService.GetAllValidateursAsync();

            if (validateurs == null)
            {
                return NotFound();
            }

            return Ok(validateurs);
        }

        // DELETE: api/Validateurs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteValidateurById(int id)
        {
            var result = await _validateurService.DeleteValidateurByIdAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
