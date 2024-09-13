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

        [HttpGet("GetAllBooks")]
        public async Task<ActionResult<IQueryable<BookDTO>>> GetAllBooks()
        {
            var request = await _repository.GetAllBooks();
            return Ok(request);
        }

        [HttpGet("GetBookByBookId")]
        public async Task<ActionResult<IQueryable<BookDTO>>> GetBookByBookId(int book_id)
        {
            var request = await _repository.GetBookByBookId(book_id);
            return Ok(request);
        }

        [HttpPost("CreateBook")]
        public async Task<ActionResult<IQueryable<BookDTO>>> CreateBook([FromBody] BookDTO bookDTO)
        {
            var request = await _repository.CreateBook(bookDTO);
            return Ok(request);
        }

        [HttpPut("UpdateBook")]
        public async Task<ActionResult<IQueryable<BookDTO>>> UpdateBook([FromBody] BookDTO updateBook)
        {
            var request = await _repository.UpdateBook(updateBook);
            return Ok(request);
        }
    }
}
