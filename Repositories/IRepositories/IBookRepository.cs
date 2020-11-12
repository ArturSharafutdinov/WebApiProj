using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProj.Models;

namespace WebApiProj.Repositories
{
    public interface IBookRepository
    {
            IEnumerable<Book> GetAll(); // получение всех объектов
            Book GetById(int id); // получение одного объекта по id
            void Create(Book item); // создание объекта
            void Update(Book item); // обновление объекта
            void Delete(int id); // удаление объекта по id
            void Save();  // сохранение изменений
            bool Exists(int id); // проверка на null
        }
}
