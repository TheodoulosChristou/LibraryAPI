using LIbraryAPI.DTOs.AuthorBook;
using LIbraryAPI.DTOs.Order;
using Microsoft.AspNetCore.Mvc;

namespace LIbraryAPI.Repository
{
    public interface IUnitOfWork
    {
        public IAuthorRepository IAuthorRepository { get; }

        public IBookRepository IBookRepository { get; }

        public IPublishRepository IPublishRepository { get; }

        public IUserRepository IUserRepository { get; }

        public IOrderRepository IOrderRepository { get; }



        public Task<List<SearchAuthorBookResultDto>> SearchAuthorBooksByCriteria(SearchAuthorBookCriteriaDto searchCriteria);
        
        public Task<List<SearchOrderResultDto>> SearchOrders(SearchOrderCriteriaDto searchCriteria);
    }
}
