using Microsoft.AspNetCore.Mvc;
using PrevisionBackend.DTO;
using PrevisionBackend.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrevisionBackend.Controllers
{
    [Route("api/systemVersion")]
    [ApiController]
    public class SystemVersionController : ControllerBase
    {
        private SystemVersionService SystemVersionService { get; set; }

        public SystemVersionController(SystemVersionService sys) {
            SystemVersionService = sys;
        
        }

        // GET: api/<SystemVersionController>
        [HttpGet]
        public async Task<IEnumerable<SystemVersionReadDto>> Get()
        {
         
            return await SystemVersionService.GetAllAsync();
        }
        [HttpGet("get-by-farmId/{fermeId}")]
        public async Task<ActionResult<SystemVersionReadDto>> GetByFarmId(string fermeId)
        {
            // Correction: Appeler la méthode du service via l'instance _systemVersionService
            var systemVersionDto = await SystemVersionService.GetSystemVersionByFarmIdAsync(fermeId);

            if (systemVersionDto == null)
            {
                return NotFound($"No SystemVersion found for Ferme with ID: {fermeId}"); // Retourne 404 si non trouvé
            }

            return Ok(systemVersionDto); // Retourne 200 OK avec le DTO
        }




        // GET api/<SystemVersionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SystemVersionController>
        [HttpPost]
        public async Task<ActionResult<SystemVersionReadDto>>Post([FromBody] SystemVersionCreateDto dto)
        {
            if (dto == null)
                return BadRequest();
            try {
                var created = await SystemVersionService.CreateSystemVersionAsync(dto);
               return Ok(created); }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            };


        }

        // PUT api/<SystemVersionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SystemVersionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
