using Book_BL.Repository;
using Book_DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IDataRepository<Book> _dataRepository;
        public BookController(IDataRepository<Book> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/Book
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Book> Books = _dataRepository.GetAll();
            return Ok(Books);
        }
        // GET: api/Book/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           Book Book = _dataRepository.Get(id);
            if (Book == null)
            {
                return NotFound("The Book record couldn't be found.");
            }
            return Ok(Book);
        }
        // POST: api/Book
        [HttpPost]
        public IActionResult Post([FromBody] Book Book)
        {
            _dataRepository.Insert(Book);
            return Ok("Book is Added");
        }
        // PUT: api/Book/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book Book)
        {
            if (Book == null)
            {
                return BadRequest("Book is null.");
            }
            Book BookToUpdate = _dataRepository.Get(id);
            if (BookToUpdate == null)
            {
                return NotFound("The Book record couldn't be found.");
            }
            
            _dataRepository.Update(BookToUpdate,Book);
            return NoContent();
        }
        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Book book = _dataRepository.Get(id);
            if (book == null)
            {
                return NotFound("The Book record couldn't be found.");
            }
            _dataRepository.Delete(book);
            return Ok("Deleted...");
        }
    }
}