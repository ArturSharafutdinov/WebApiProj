﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        private readonly BooksContext _booksContext;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, BooksContext booksContext, IMapper mapper)
        {
            _bookService = bookService;
            _booksContext = booksContext;
            _mapper = mapper;
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
            bookDto.DateIn = DateTime.Now;
            bookDto.isHave = true;
            _bookService.updateBook(bookDto);
            return Ok("changed");

        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(BookDetailDto bookDetailDto)
        {
           
            await _booksContext.AddAsync(_mapper.Map<Book>(bookDetailDto));
            await _booksContext.SaveChangesAsync();

            int lastId = _booksContext.Books.ToList().Max(x => x.BookId);

            return _booksContext.Books.Find(lastId);
        }

        [Authorize]
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
