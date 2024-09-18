using AutoMapper;
using LIbraryAPI.DTOs.Author;
using LIbraryAPI.DTOs.Book;
using LIbraryAPI.DTOs.Publish;
using LIbraryAPI.DTOs.User;
using LIbraryAPI.Entity;

namespace LIbraryAPI.Mapping
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookDto, Book>().ReverseMap();
            CreateMap<AuthorDto, Author>().ReverseMap();
            CreateMap<PublishDto, Publish>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
