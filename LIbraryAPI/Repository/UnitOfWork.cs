using LIbraryAPI.DTOs.AuthorBook;

namespace LIbraryAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAuthorRepository IAuthorRepository { get; private set; }

        public IBookRepository IBookRepository { get; private set; }

        public IPublishRepository IPublishRepository { get; private set; }

        public UnitOfWork(IAuthorRepository iAuthorRepository, IBookRepository iBookRepository, IPublishRepository iPublishRepository)
        {
            IAuthorRepository = iAuthorRepository;
            IBookRepository = iBookRepository;
            IPublishRepository = iPublishRepository;
        }

        public async Task<List<SearchAuthorBookResultDto>> SearchAuthorBooksByCriteria(SearchAuthorBookCriteriaDto searchCriteria)
        {
            try
            {
                var authorList = await IAuthorRepository.GetAllAuthors();
                var bookList = await IBookRepository.GetAllBooks();
                var publishList = await IPublishRepository.GetAllPublish();


                List<SearchAuthorBookResultDto> finalResult = (from author in authorList
                                                               join publish in publishList on author.AUTHOR_ID equals publish.AUTHOR_ID into jt1
                                                               from publish in jt1.DefaultIfEmpty()
                                                               join book in bookList on publish.BOOK_ID equals book.BOOK_ID into jt2
                                                               from book in jt2.DefaultIfEmpty()
                                                               where
                                                                  ((author.AUTHOR_ID == searchCriteria.AUTHOR_ID) || searchCriteria.AUTHOR_ID == null)
                                                                  && ((searchCriteria.AUTHOR_NAME != null && author.AUTHOR_NAME.Contains(searchCriteria.AUTHOR_NAME)) || searchCriteria.AUTHOR_NAME == null)
                                                                  && ((searchCriteria.AUTHOR_SURNAME != null && author.AUTHOR_SURNAME.Contains(searchCriteria.AUTHOR_SURNAME)) || searchCriteria.AUTHOR_SURNAME == null)
                                                                  && ((searchCriteria.AGE != null && author.AGE == searchCriteria.AGE) || searchCriteria.AGE == null)
                                                                  && ((searchCriteria.BOOK_ID != null && book.BOOK_ID == searchCriteria.BOOK_ID) || searchCriteria.BOOK_ID == null)
                                                                  && ((searchCriteria.BOOK_NAME != null && book.BOOK_NAME.Contains(searchCriteria.BOOK_NAME)) || searchCriteria.BOOK_NAME == null)
                                                               select new SearchAuthorBookResultDto
                                                               {
                                                                   AUTHOR_ID = author.AUTHOR_ID,
                                                                   AUTHOR_NAME = author.AUTHOR_NAME,
                                                                   AUTHOR_SURNAME = author.AUTHOR_SURNAME,
                                                                   AGE = author.AGE,
                                                                   BOOK_ID = book != null ? book.BOOK_ID : null,
                                                                   BOOK_NAME = book != null ? book.BOOK_NAME : null,
                                                                   DATE_PUBLISHED = book != null ? book.DATE_PUBLISHED : null
                                                               }).ToList();


                return finalResult;
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
