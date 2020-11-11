using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProj.Dto;
using WebApiProj.IServices;
using WebApiProj.Models;
using WebApiProj.Repositories;

namespace WebApiProj.Services
{
    public class BookService : BookRepository,IBookService
    {
    private readonly BookRepository _bookRep;
        private readonly IMapper _mapper;
        public BookService(BookRepository bookRepository, IMapper mapper, BooksContext context) : base(context)
        {
            _bookRep = bookRepository;
            _mapper = mapper;
        }


        public void addBook(BookDetailDto bookDto)
        {
            Book book = _mapper.Map<Book>(bookDto);
            _bookRep.Create(book);
            _bookRep.Save();
        }

        public IEnumerable<BookDto> getAllBooks(){
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDto>>(_bookRep.GetAll());
            }

        public BookDetailDto getBookById(int id)
        {
            return _mapper.Map<BookDetailDto>(_bookRep.GetById(id));
        }


    }
}
