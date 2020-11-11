using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProj.Dto;
using WebApiProj.Models;

namespace WebApiProj.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private BooksContext db;
        public BookRepository(BooksContext booksContext)
        {
            db = booksContext;
        }

        public void Create(Book item)
        {
            db.Add(item);
        }

        public void Delete(int id)
        {
            db.Remove(id);
        }


        public Book GetBook(int id)
        {
            return db.Books.Find(id);
        }

        public IEnumerable<Book> GetBookList()
        {
            return db.Books.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Book item)
        {
            db.Books.Update(item);
        }

        public bool Exists(int id)
        {
            return GetBook(id) != null;
        }
    }
}
