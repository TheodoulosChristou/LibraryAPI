using AutoMapper;
using LIbraryAPI.DataContext;
using LIbraryAPI.DTOs.Author;
using LIbraryAPI.Entity;
using LIbraryAPI.Validator;

namespace LIbraryAPI.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IMapper _mapper;

        private readonly ProjectDbContext _dbContext;

        public AuthorRepository(IMapper mapper, ProjectDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<AuthorDto> CreateAuthor(AuthorDto author)
        {
           try
            {
                var validator = new AuthorDtoValidator();
                var valid = await validator.ValidateAsync(author);

                if(valid.IsValid == false)
                {
                    throw new Exception("CANT CREATE AUTHOR. VALIDATION FAILED");
                } else
                {
                    var authorRequest = _mapper.Map<Author>(author);
                    _dbContext.Author.Add(authorRequest);
                    _dbContext.SaveChanges();

                    AuthorDto result = _mapper.Map<AuthorDto>(authorRequest);
                    return result;
                }

                
            }catch (Exception ex)
            {
                throw ex;
            }
                
        }

        public Task<BaseCommandResponse.BaseCommandResponse> DeleteAuthor(AuthorDto author)
        {
            throw new NotImplementedException();
        }

        public Task<List<AuthorDto>> GetAllAuthors()
        {
            throw new NotImplementedException();
        }

        public Task<AuthorDto> GetAuthorById(int author_id)
        {
            throw new NotImplementedException();
        }

        public Task<AuthorDto> UpdateAuthor(AuthorDto author)
        {
            throw new NotImplementedException();
        }
    }
}
