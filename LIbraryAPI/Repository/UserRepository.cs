using AutoMapper;
using LIbraryAPI.BaseCommandResponse;
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

        public async Task<BaseCommandResponse.BaseCommandResponse> DeleteUser(UserDto deleteUser)
        {
            try
            {
                BaseCommandResponse.BaseCommandResponse result = new BaseCommandResponse.BaseCommandResponse();
                var validator = new UpdateDeleteUserDtoValidator();
                var valid = await validator.ValidateAsync(deleteUser);

                if(valid.IsValid == false)
                {
                    throw new Exception("Failed to update the user object. Validation Failed");
                } else
                {
                    var userRequest = _mapper.Map<User>(deleteUser);
                    _dbContext.User.Remove(userRequest);
                    _dbContext.SaveChanges();

                    result.ID = userRequest.USER_ID;
                    result.MESSAGE = "User has been deleted successfully";
                    result.ENTITY = "USER";

                    return result;
                }

            }catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            try
            {
                var userList = _dbContext.User.ToList();
                List<UserDto> result = _mapper.Map<List<UserDto>>(userList);
                return result;
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserDto> GetUserById(int id)
        {
            try
            {
                var userRequest = _dbContext.User.FirstOrDefault(x=>x.USER_ID==id);
                UserDto result = _mapper.Map<UserDto>(userRequest); 
                return result;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UserDto>> SearchUserByCriteria(SearchUserByCriteriaDto searchCriteria)
        {
            try
            {
                var userList = _dbContext.User.Where(x =>
                        (x.USER_ID == searchCriteria.USER_ID || searchCriteria.USER_ID == null)
                        && (x.FIRST_NAME.Contains(searchCriteria.FIRST_NAME) || searchCriteria.FIRST_NAME == null)
                        && (x.LAST_NAME.Contains(searchCriteria.LAST_NAME) || searchCriteria.LAST_NAME == null)
                        && (x.ADDRESS.Contains(searchCriteria.ADDRESS) || searchCriteria.ADDRESS == null)
                        && (x.PHONE_NUMBER.Contains(searchCriteria.PHONE_NUMBER) || searchCriteria.PHONE_NUMBER == null)
                        && (x.EMAIL.Contains(searchCriteria.EMAIL) || searchCriteria.EMAIL == null)).ToList();

                List<UserDto> result = _mapper.Map<List<UserDto>>(userList);
                return result;


            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<UserDto> UpdateUser(UserDto updateUser)
        {
            try
            {
                var validator = new UpdateDeleteUserDtoValidator();
                var valid = await validator.ValidateAsync(updateUser);

                if(valid.IsValid == false)
                {
                    throw new Exception("Failed to update the user object. Validation Failed");
                } else
                {
                    var userRequest = _mapper.Map<User>(updateUser);
                    _dbContext.User.Update(userRequest);
                    _dbContext.SaveChanges();

                    return updateUser;
                }
            }catch (Exception e)
            {
                throw e;
            }
        }
    }
}
