using LIbraryAPI.DTOs.Book;
using LIbraryAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LIbraryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repository;

        public BookController(IBookRepository repository)
        {
            _repository = repository;   
        }

        [HttpPost("CreateBook")]
        public async Task<ActionResult<IQueryable<BookDTO>>> CreateBook([FromBody] BookDTO bookDTO)
        {
            var request = await _repository.CreateBook(bookDTO);
            return Ok(request);
        }
    }
}
