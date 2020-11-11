using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProj.Dto;
using WebApiProj.IServices;
using WebApiProj.Models;
using WebApiProj.Repositories;
using WebApiProj.Services;

namespace WebApiProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/Books
        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> GetBooks()
        {
            return _bookService.getAllBooks().ToList();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public ActionResult<BookDetailDto> GetBook(int id)
        {
            return _bookService.getBookById(id);
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutBook(int id, Book book)
        {
            return null;
        }

        // POST: api/Books
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Book> PostBook(Book book)
        {
         

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
