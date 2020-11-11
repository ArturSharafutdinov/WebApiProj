using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProj.Dto;
using WebApiProj.Models;

namespace WebApiProj
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
            CreateMap<Book, BookDetailDto>();
            CreateMap<BookDetailDto,Book>();
            CreateMap<CommentDto, Comment>();
            CreateMap<Comment, CommentDto>();
        }
    }
}
