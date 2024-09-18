using LIbraryAPI.DTOs.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LIbraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<IQueryable<UserDto>>> CreateUser([FromBody] UserDto createUser)
        {
            var request = await _repository.CreateUser(createUser);
            return Ok(request);
        }
    }
}
