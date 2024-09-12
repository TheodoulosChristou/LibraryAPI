using AutoMapper;
using LIbraryAPI.DataContext;
using LIbraryAPI.DTOs.Book;
using LIbraryAPI.Entity;
using LIbraryAPI.Validator;

namespace LIbraryAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ProjectDbContext _dbContext;

        private readonly IMapper _mapper;

        public BookRepository(ProjectDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<BookDTO> CreateBook(BookDTO book)
        {
            try
            {
                var validator = new BookDtoValidator();
                var valid = await validator.ValidateAsync(book);    

                if(valid.IsValid == false)
                {
                    throw new Exception();
                } else
                {
                    var bookRequest = _mapper.Map<Book>(book);
                    _dbContext.Add(bookRequest);
                    _dbContext.SaveChanges();

                    var result = _mapper.Map<BookDTO>(bookRequest);    
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteBook(BookDTO book)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookDTO>> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Task<BookDTO> GetBookByBookId(int book_id)
        {
            throw new NotImplementedException();
        }

        public Task<BookDTO> UpdateBook(BookDTO book)
        {
            throw new NotImplementedException();
        }
    }
}
