using AutoMapper;
using LIbraryAPI.DTOs.Author;
using LIbraryAPI.DTOs.Book;
using LIbraryAPI.Entity;

namespace LIbraryAPI.Mapping
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookDto, Book>().ReverseMap();
            CreateMap<AuthorDto, Author>().ReverseMap();
        }
    }
}
