
using LIbraryAPI.DTOs.Book;

namespace LIbraryAPI.Repository
{
    public interface IBookRepository
    {
        public Task<List<BookDto>> GetAllBooks();

        public Task<BookDto> GetBookByBookId(int book_id);

        public Task<BookDto> CreateBook(BookDto book);

        public Task<BookDto> UpdateBook(BookDto book);

        public Task<BaseCommandResponse.BaseCommandResponse> DeleteBook(BookDto book);

        public Task<List<BookDto>> SearchBooksByCriteria(SearchBookCriteriaDto searchCriteria);
    }
}
