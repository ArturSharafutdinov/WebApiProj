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
        public ActionResult<IEnumerable<BookDetailDto>> GetBooks()
        {
            return _bookService.getAllBooks().OrderBy(q => q.BookId).ToList();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public ActionResult<BookDetailDto> GetBook(int id)
        {
            return _bookService.getBookById(id);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public IActionResult PutBook(int id, BookDetailDto bookDto)
        {
            bookDto.BookId = id;
            _bookService.updateBook(bookDto);
            return Ok("changed");

        }

        // POST: api/Books
        [HttpPost]
        public IActionResult PostBook(BookDetailDto bookDetailDto)
        {
            _bookService.addBook(bookDetailDto);


            return Ok("added");
        }

            // DELETE: api/Books/5
           [HttpDelete("{id}")]
           public ActionResult DeleteBook(int id)
           {
            var book = _bookService.getBookById(id);
               if (book == null)
               {
                   return NotFound();
               }

            _bookService.removeBook(id);

               return Ok("removed");
           }

    }
}
