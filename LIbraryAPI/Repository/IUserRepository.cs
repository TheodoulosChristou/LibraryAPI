
using LIbraryAPI.BaseCommandResponse;
using LIbraryAPI.DTOs.User;

public interface IUserRepository
    {
        public Task<List<UserDto>> GetAllUsers();

        public Task<UserDto> GetUserById(int id);

        public Task<UserDto> CreateUser(UserDto createUser);

        public Task<UserDto> UpdateUser(UserDto updateUser);

        public Task<BaseCommandResponse> DeleteUser(UserDto deleteUser);

        public Task<List<UserDto>> SearchUserByCriteria(SearchUserByCriteriaDto searchCriteria);
    }

