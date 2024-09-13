using LIbraryAPI.DTOs.Author;
using LIbraryAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LIbraryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _repository;

        public AuthorController(IAuthorRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("CreatAuthor")]
        public async Task<ActionResult<IQueryable<AuthorDto>>> CreatAuthor([FromBody] AuthorDto createAuthor)
        {
            var request = await _repository.CreateAuthor(createAuthor);
            return Ok(request);
        }
    }
}
