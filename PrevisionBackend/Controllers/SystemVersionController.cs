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
