
using Book_BL.Repository;
using Book_DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookUserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookUserController : ControllerBase
    {
        private readonly IDataRepository<BookUser> _dataRepository;
        public BookUserController(IDataRepository<BookUser> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/<BookUserController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<BookUser> BookUsers = _dataRepository.GetAll();
            return Ok(BookUsers);
        }

        // GET api/<BookUserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            BookUser BookUser = _dataRepository.Get(id);
            if (BookUser == null)
            {
                return NotFound("The Book record couldn't be found.");
            }
            return Ok(BookUser);
        }

        // POST api/<BookUserController>
        [HttpPost]
        public IActionResult Post([FromBody] BookUser value)
        {
            _dataRepository.Insert(value);
            return Ok("BookUser is Added");
        }

        // PUT api/<BookUserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BookUser value)
        {
            if (value == null)
            {
                return BadRequest("Book is null.");
            }
            BookUser BookToUpdate = _dataRepository.Get(id);
            if (BookToUpdate == null)
            {
                return NotFound("The Book record couldn't be found.");
            }

            _dataRepository.Update(BookToUpdate, value);
            return NoContent();
        }

        // DELETE api/<BookUserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            BookUser bookUser = _dataRepository.Get(id);

            _dataRepository.Delete(bookUser);
            return Ok();


        }
    }
}
