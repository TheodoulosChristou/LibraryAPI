﻿using AutoMapper;
using LIbraryAPI.DTOs.Book;
using LIbraryAPI.Entity;

namespace LIbraryAPI.Mapping
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookDTO, Book>().ReverseMap();
        }
    }
}
