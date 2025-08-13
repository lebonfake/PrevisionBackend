using Microsoft.AspNetCore.Mvc;
using PrevisionBackend.DTO;
using PrevisionBackend.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrevisionBackend.Controllers
{

 
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private UserService _userService;

        public UserController(UserService _userService)
        {
            this._userService = _userService;

        }


        // GET: api/<UserController
        [HttpGet]
        public async Task<ActionResult<List<UserReadDto>>> Get()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users); // returns 200 OK with the data
        }
 

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
