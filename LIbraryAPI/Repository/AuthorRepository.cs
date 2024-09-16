using AutoMapper;
using LIbraryAPI.BaseCommandResponse;
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

        public async Task<BaseCommandResponse.BaseCommandResponse> DeleteAuthor(AuthorDto author)
        {
            try
            {
                BaseCommandResponse.BaseCommandResponse result = new BaseCommandResponse.BaseCommandResponse();
                var validator = new UpdateDeleteAuthorDtoValidator();
                var valid = await validator.ValidateAsync(author);

                if(valid.IsValid == false)
                {
                    throw new Exception("Failed to Delete the object. Validation failed");
                } else
                {
                    var deleteAuthorRequest = _mapper.Map<Author>(author);
                    _dbContext.Author.Remove(deleteAuthorRequest);
                    _dbContext.SaveChanges();

                    result.ID = deleteAuthorRequest.AUTHOR_ID;
                    result.MESSAGE = "Author Object has been deleted successfully";
                    result.ENTITY = "AUTHOR";

                    return result;

                }

            }catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<AuthorDto>> GetAllAuthors()
        {
            try
            {
                List<Author> authorList = _dbContext.Author.ToList();
                List<AuthorDto> result = _mapper.Map<List<AuthorDto>>(authorList);  
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AuthorDto> GetAuthorById(int author_id)
        {
            try
            {
                var author = _dbContext.Author.FirstOrDefault(x => x.AUTHOR_ID == author_id);
                AuthorDto result = _mapper.Map<AuthorDto>(author);
                return result;
            }catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<AuthorDto>> SearchAuthorsByCriteria(SearchAuthorsByCriteriaDto searchCriteria)
        {
            try
            {
                var authorList = _dbContext.Author.ToList();
                var query = authorList.Where(x =>
                                                (searchCriteria.AUTHOR_ID == null || x.AUTHOR_ID == searchCriteria.AUTHOR_ID)
                                                && (searchCriteria.AUTHOR_NAME == null || x.AUTHOR_NAME.Contains(searchCriteria.AUTHOR_NAME))
                                                && (searchCriteria.AUTHOR_SURNAME == null || x.AUTHOR_SURNAME.Contains(searchCriteria.AUTHOR_SURNAME))
                                                && (searchCriteria.AGE == null || x.AGE == searchCriteria.AGE)).ToList();

                List<AuthorDto> result = _mapper.Map<List<AuthorDto>>(query);   
                return result;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AuthorDto> UpdateAuthor(AuthorDto author)
        {
            try
            {
                var validator = new UpdateDeleteAuthorDtoValidator();
                var valid = await validator.ValidateAsync(author);

                if(valid.IsValid == false)
                {
                    throw new Exception("Failed to Update the Author Object. Validation Failed");
                } else
                {
                    var authorUpdateRequest = _mapper.Map<Author>(author);
                    _dbContext.Author.Update(authorUpdateRequest);
                    _dbContext.SaveChanges();

                    return author;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
