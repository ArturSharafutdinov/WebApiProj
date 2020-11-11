using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProj.Dto;
using WebApiProj.Models;
using WebApiProj.Repositories;

namespace WebApiProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookRepository _bookRep;
        private readonly IMapper _mapper;

        public BooksController(BookRepository bookRepository, IMapper mapper)
        {
            _bookRep = bookRepository;
            _mapper = mapper;
        }

        // GET: api/Books
        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> GetBooks()
        {
            var books = _bookRep.GetBookList();
            var booksDto = _mapper.Map<List<BookDto>>(books);
            return booksDto;
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public ActionResult<BookDetailDto> GetBook(int id)
        {
            var book = _bookRep.GetBook(id);

            var bookDto = _mapper.Map<BookDetailDto>(book);

            return bookDto;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutBook(int id, Book book)
        {
            if (id != book.BookId)
            {
                return BadRequest();
            }

            if (!_bookRep.Exists(id))
            {
                return NotFound();
            }

            _bookRep.Update(book);

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Book> PostBook(Book book)
        {
            _bookRep.Create(book);
            _bookRep.Save();

            // return CreatedAtAction(nameof(GetBook), new { id = book.BookId }, book);

            return NoContent();
        }

        /*
            // DELETE: api/Books/5
           [HttpDelete("{id}")]
           public ActionResult<Book> DeleteBook(int id)
           {
               var book = await _context.Books.FindAsync(id);
               if (book == null)
               {
                   return NotFound();
               }

               _context.Books.Remove(book);
               await _context.SaveChangesAsync();

               return book;
           }
         */

    }
}
