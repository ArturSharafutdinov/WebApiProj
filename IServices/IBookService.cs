using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProj.Dto;
using WebApiProj.Repositories;

namespace WebApiProj.IServices
{
    public interface IBookService : IBookRepository
    { 


        public void addBook(BookDetailDto bookDto);


        public IEnumerable<BookDto> getAllBooks();


        public BookDetailDto getBookById(int id);

    }
}
