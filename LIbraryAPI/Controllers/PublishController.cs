using LIbraryAPI.DTOs.AuthorBook;
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

        private readonly IUnitOfWork _unitOfWork;

        public PublishController(IPublishRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("PublishBook")]
        public async Task<ActionResult<IQueryable<PublishDto>>> PublishBook([FromBody] PublishDto publishDto)
        {
            var request = await _repository.PublishBookAuthor(publishDto);
            return Ok(request);
        }

        [HttpPost("SearchAuthorBookByCriteria")]
        public async Task<ActionResult<IQueryable<SearchAuthorBookResultDto>>> SearchAuthorBookByCriteria([FromBody] SearchAuthorBookCriteriaDto searchCriteria)
        {
            var request = await _unitOfWork.SearchAuthorBooksByCriteria(searchCriteria);
            return Ok(request);
        }

        [HttpPut("UpdatePublishBook")]
        public async Task<ActionResult<IQueryable<PublishDto>>> UpdatePublishBook([FromBody] PublishDto publishDto)
        {
            var request = await _repository.UpdatePublishBookAuthor(publishDto);
            return Ok(request);
        }
    }
}
