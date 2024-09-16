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

        [HttpGet("GetAllAuthors")]
        public async Task<ActionResult<IQueryable<AuthorDto>>> GetAllAuthors()
        {
            var request = await _repository.GetAllAuthors();
            return Ok(request);
        }

        [HttpGet("GetAuthorById")]
        public async Task<ActionResult<IQueryable<AuthorDto>>> GetAuthorById(int author_id)
        {
            var request = await _repository.GetAuthorById(author_id);
            return Ok(request);
        }

        [HttpPost("CreateAuthor")]
        public async Task<ActionResult<IQueryable<AuthorDto>>> CreatAuthor([FromBody] AuthorDto createAuthor)
        {
            var request = await _repository.CreateAuthor(createAuthor);
            return Ok(request);
        }

        [HttpPost("SearchAuthorByCriteria")]
        public async Task<ActionResult<IQueryable<AuthorDto>>> SearchAuthorByCriteria([FromBody] SearchAuthorsByCriteriaDto searchCriteria)
        {
            var request = await _repository.SearchAuthorsByCriteria(searchCriteria);
            return Ok(request);
        }

        [HttpPut("UpdateAuthor")]
        public async Task<ActionResult<IQueryable<AuthorDto>>> UpdateAuthor([FromBody] AuthorDto createAuthor)
        {
            var request = await _repository.UpdateAuthor(createAuthor);
            return Ok(request);
        }

        [HttpDelete("DeleteAuthor")]
        public async Task<ActionResult<BaseCommandResponse.BaseCommandResponse>> DeleteAuthor([FromBody] AuthorDto createAuthor)
        {
            var request = await _repository.DeleteAuthor(createAuthor);
            return Ok(request);
        }
    }
}
