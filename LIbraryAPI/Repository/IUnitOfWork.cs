using LIbraryAPI.DTOs.AuthorBook;
using Microsoft.AspNetCore.Mvc;

namespace LIbraryAPI.Repository
{
    public interface IUnitOfWork
    {
        public IAuthorRepository IAuthorRepository { get; }

        public IBookRepository IBookRepository { get; }

        public IPublishRepository IPublishRepository { get; }

        public Task<List<SearchAuthorBookResultDto>> SearchAuthorBooksByCriteria(SearchAuthorBookCriteriaDto searchCriteria);
    }
}
