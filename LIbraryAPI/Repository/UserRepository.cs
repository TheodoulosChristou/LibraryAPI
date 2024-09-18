using AutoMapper;
using LIbraryAPI.DataContext;
using LIbraryAPI.DTOs.User;
using LIbraryAPI.Entity;
using LIbraryAPI.Validator;

namespace LIbraryAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ProjectDbContext _dbContext;

        private readonly IMapper _mapper;

        public UserRepository(ProjectDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<UserDto> CreateUser(UserDto createUser)
        {
            try
            {
                var validator = new UserDtoValidator();
                var valid = await validator.ValidateAsync(createUser);

                if(valid.IsValid == false)
                {
                    throw new Exception("Failed to create User. Validation Failed");
                } else
                {
                    var userRequest = _mapper.Map<User>(createUser);
                    _dbContext.User.Add(userRequest);
                    _dbContext.SaveChanges();

                    UserDto result = _mapper.Map<UserDto>(userRequest);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<BaseCommandResponse.BaseCommandResponse> DeleteUser(UserDto deleteUser)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDto>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> UpdateUser(UserDto updateUser)
        {
            throw new NotImplementedException();
        }
    }
}
