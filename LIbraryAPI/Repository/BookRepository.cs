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


        public async Task<BookDto> CreateBook(BookDto book)
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

                    var result = _mapper.Map<BookDto>(bookRequest);    
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseCommandResponse.BaseCommandResponse> DeleteBook(BookDto book)
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

        public async Task<List<BookDto>> GetAllBooks()
        {
            try
            {
                List<Book> bookList =  _dbContext.Book.ToList();
                List<BookDto> result = _mapper.Map<List<BookDto>>(bookList);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BookDto> GetBookByBookId(int book_id)
        {
            try
            {
                var book = _dbContext.Book.FirstOrDefault(x=>x.BOOK_ID == book_id);
                BookDto result = _mapper.Map<BookDto>(book);
                return result;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BookDto>> SearchBooksByCriteria(SearchBookCriteriaDto searchCriteria)
        {
            try
            {
                List<Book> bookList =  _dbContext.Book
                    .Where(x => (x.BOOK_ID == searchCriteria.BOOK_ID || searchCriteria.BOOK_ID == null)
                            &&(searchCriteria.BOOK_NAME == null || x.BOOK_NAME.Contains(searchCriteria.BOOK_NAME))
                            && (searchCriteria.DATE_PUBLISHED == null || x.DATE_PUBLISHED == searchCriteria.DATE_PUBLISHED) )
                    .ToList();
                List<BookDto> result = _mapper.Map<List<BookDto>>(bookList);
                return result;

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BookDto> UpdateBook(BookDto book)
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

                    BookDto result = _mapper.Map<BookDto>(bookRequest);
                    return result;
                }
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
