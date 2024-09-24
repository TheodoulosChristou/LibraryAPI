using LIbraryAPI.DTOs.AuthorBook;
using LIbraryAPI.DTOs.Order;

namespace LIbraryAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAuthorRepository IAuthorRepository { get; private set; }

        public IBookRepository IBookRepository { get; private set; }

        public IPublishRepository IPublishRepository { get; private set; }

        public IUserRepository IUserRepository { get; private set; }

        public IOrderRepository IOrderRepository { get; private set; }

        public UnitOfWork(IAuthorRepository iAuthorRepository, IBookRepository iBookRepository, IPublishRepository iPublishRepository, IUserRepository userRepository, IOrderRepository orderRepository)
        {
            IAuthorRepository = iAuthorRepository;
            IBookRepository = iBookRepository;
            IPublishRepository = iPublishRepository;
            IOrderRepository = orderRepository;
            IUserRepository = userRepository;
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

        public async Task<List<SearchOrderResultDto>> SearchOrders(SearchOrderCriteriaDto searchCriteria)
        {
            try
            {
                var orders = await IOrderRepository.GetAllOrders();
                var users = await IUserRepository.GetAllUsers();
                var authors = await IAuthorRepository.GetAllAuthors();
                var publishes = await IPublishRepository.GetAllPublish();
                var books = await IBookRepository.GetAllBooks();

                List<SearchOrderResultDto> res = (from o in orders
                                                  join u in users on o.USER_ID equals u.USER_ID into jt1
                                                  from u in jt1.DefaultIfEmpty()
                                                  join b in books on o.BOOK_ID equals b.BOOK_ID into jt2
                                                  from b in jt2.DefaultIfEmpty()
                                                  join p in publishes on o.BOOK_ID equals p.BOOK_ID into jt3
                                                  from p in jt3.DefaultIfEmpty()
                                                  join a in authors on p.AUTHOR_ID equals a.AUTHOR_ID into jt4
                                                  from a in jt4.DefaultIfEmpty()
                                                  where  
                                                  ( (searchCriteria.BOOK_NAME == null) || searchCriteria.BOOK_NAME != null && b.BOOK_NAME.Contains(searchCriteria.BOOK_NAME) )
                                                  && ( (searchCriteria.USER_FIRSTNAME == null) || searchCriteria.USER_FIRSTNAME !=null && u.FIRST_NAME.Contains(searchCriteria.USER_FIRSTNAME) )
                                                  && ((searchCriteria.USER_LASTNAME == null) || searchCriteria.USER_LASTNAME != null && u.LAST_NAME.Contains(searchCriteria.USER_LASTNAME))
                                                  select new SearchOrderResultDto
                                                  {
                                                      ORDER_ID = o == null ? null : o.ORDER_ID,
                                                      BOOK_ID = o == null ? null : o.BOOK_ID,
                                                      USER_ID = o == null ? null :o.USER_ID,
                                                      USER_FIRSTNAME = o == null ? null : u.FIRST_NAME,
                                                      USER_LASTNAME = o == null ? null : u.LAST_NAME,
                                                      BOOK_NAME = o == null ? null : b.BOOK_NAME,
                                                      AUTHOR_NAME = o == null ? null : a.AUTHOR_NAME

                                                  }).ToList();

                return res;
                                                 
                                                  
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
