using LIbraryAPI.DTOs.Author;

namespace LIbraryAPI.Repository
{
    public interface IAuthorRepository
    {
        public Task<List<AuthorDto>> GetAllAuthors();

        public Task<AuthorDto> GetAuthorById(int author_id);

        public Task<AuthorDto> CreateAuthor(AuthorDto author);  

        public Task<AuthorDto> UpdateAuthor(AuthorDto author);

        public Task<BaseCommandResponse.BaseCommandResponse> DeleteAuthor(AuthorDto author);

        public Task<List<AuthorDto>> SearchAuthorsByCriteria(SearchAuthorsByCriteriaDto searchCriteria);
    }
}
