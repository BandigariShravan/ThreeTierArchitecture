using Book_BL.Repository;
using Book_DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDataRepository<User> _dataRepository;
        public UserController(IDataRepository<User> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<User> Users = _dataRepository.GetAll();
            return Ok(Users);
        }
        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User User = _dataRepository.Get(id);
            if (User == null)
            {
                return NotFound("The User record couldn't be found.");
            }
            return Ok(User);
        }
        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] User User)
        {
            _dataRepository.Insert(User);
            return Ok("User is Added");
        }
        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User User)
        {
            if (User == null)
            {
                return BadRequest("User is null.");
            }
            User UserToUpdate = _dataRepository.Get(id);
            if (UserToUpdate == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            _dataRepository.Update(UserToUpdate,User);
            return NoContent();
        }
        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User User = _dataRepository.Get(id);
            if (User == null)
            {
                return NotFound("The User record couldn't be found.");
            }
            _dataRepository.Delete(User);
            return NoContent();
        }
    }
}
