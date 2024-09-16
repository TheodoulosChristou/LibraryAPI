using LIbraryAPI.DTOs.Publish;
using LIbraryAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LIbraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishController : ControllerBase
    {
        private readonly IPublishRepository _repository;

        public PublishController(IPublishRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("PublishBook")]
        public async Task<ActionResult<IQueryable<PublishDto>>> PublishBook(PublishDto publishDto)
        {
            var request = await _repository.PublishBookAuthor(publishDto);
            return Ok(request);
        }
    }
}
