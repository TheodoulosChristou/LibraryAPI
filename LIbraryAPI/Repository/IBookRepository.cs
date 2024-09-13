
using LIbraryAPI.DTOs.Book;

namespace LIbraryAPI.Repository
{
    public interface IBookRepository
    {
        public Task<List<BookDTO>> GetAllBooks();

        public Task<BookDTO> GetBookByBookId(int book_id);

        public Task<BookDTO> CreateBook(BookDTO book);

        public Task<BookDTO> UpdateBook(BookDTO book);

        public Task<BaseCommandResponse.BaseCommandResponse> DeleteBook(BookDTO book);
    }
}
