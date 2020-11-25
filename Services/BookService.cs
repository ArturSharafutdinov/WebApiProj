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
    public class BookService : IBookService
    {
    private readonly IBookRepository _bookRep;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRep = bookRepository;
            _mapper = mapper;
        }


        public void addBook(BookDetailDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _bookRep.Create(book);
            _bookRep.Save();
        }

        public IEnumerable<BookDetailDto> getAllBooks(){
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDetailDto>>(_bookRep.GetAll());
            }

        public BookDetailDto getBookById(int id)
        {
            return _mapper.Map<BookDetailDto>(_bookRep.GetById(id));
        }

        public void updateBook(BookDetailDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _bookRep.Update(book);
            _bookRep.Save();
        }

        public void removeBook(int id)
        {
            _bookRep.Delete(id);
            _bookRep.Save();
        }


    }
}
