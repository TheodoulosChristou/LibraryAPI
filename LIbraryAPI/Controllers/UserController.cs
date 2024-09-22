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

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<IQueryable<UserDto>>> GetAllUsers()
        {
            var request = await _repository.GetAllUsers();
            return Ok(request);
        }

        [HttpGet("GetUserByUserId")]
        public async Task<ActionResult<IQueryable<UserDto>>> GetUserByUserId(int user_id)
        {
            var request = await _repository.GetUserById(user_id);
            return Ok(request);
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<IQueryable<UserDto>>> CreateUser([FromBody] UserDto createUser)
        {
            var request = await _repository.CreateUser(createUser);
            return Ok(request);
        }

        [HttpPost("SearchUserByCriteria")]
        public async Task<ActionResult<IQueryable<UserDto>>> SearchUserByCriteria([FromBody] SearchUserByCriteriaDto searchCriteria)
        {
            var request = await _repository.SearchUserByCriteria(searchCriteria);
            return Ok(request);
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<IQueryable<UserDto>>> UpdateUser([FromBody] UserDto updateUser)
        {
            var request = await _repository.UpdateUser(updateUser);
            return Ok(request);
        }

        [HttpDelete("DeleteUser")]
        public async Task<ActionResult<BaseCommandResponse.BaseCommandResponse>> DeleteUser([FromBody] UserDto deleteUser)
        {
            var request = await _repository.DeleteUser(deleteUser);
            return Ok(request);
        }
    }
}
