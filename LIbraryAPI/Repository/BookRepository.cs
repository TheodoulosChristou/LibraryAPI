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

        public async Task<BaseCommandResponse.BaseCommandResponse> DeleteBook(BookDTO book)
        {
            try
            {
                BaseCommandResponse.BaseCommandResponse result = new BaseCommandResponse.BaseCommandResponse();
                var validator = new UpdateDeleteBookDtoValidator();
                var valid = await validator.ValidateAsync(book);

                if(valid.IsValid == false)
                {
                    throw new Exception();
                } else
                {
                    var bookRequest = _mapper.Map<Book>(book);
                    _dbContext.Book.Remove(bookRequest);
                    _dbContext.SaveChanges();

                    result.ID = bookRequest.BOOK_ID;
                    result.MESSAGE = "Book has been successfully deleted";
                    result.ENTITY = "BOOK";

                    return result;

                }
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BookDTO>> GetAllBooks()
        {
            try
            {
                List<Book> bookList =  _dbContext.Book.ToList();
                List<BookDTO> result = _mapper.Map<List<BookDTO>>(bookList);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BookDTO> GetBookByBookId(int book_id)
        {
            try
            {
                var book = _dbContext.Book.FirstOrDefault(x=>x.BOOK_ID == book_id);
                BookDTO result = _mapper.Map<BookDTO>(book);
                return result;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BookDTO> UpdateBook(BookDTO book)
        {
            try
            {
                var validator = new UpdateDeleteBookDtoValidator();
                var valid = await validator.ValidateAsync(book);

                if(valid.IsValid == false)
                {
                    throw new Exception();
                } else
                {
                    var bookRequest = _mapper.Map<Book>(book);
                    _dbContext.Book.Update(bookRequest);
                    _dbContext.SaveChanges();

                    BookDTO result = _mapper.Map<BookDTO>(bookRequest);
                    return result;
                }
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
