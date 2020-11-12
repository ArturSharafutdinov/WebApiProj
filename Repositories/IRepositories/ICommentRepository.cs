using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProj.Models;

namespace WebApiProj.Repositories
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAll(); // получение всех объектов
        Comment GetById(int id); // получение одного объекта по id
        void Create(Comment item); // создание объекта
        void Update(Comment item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
        bool Exists(int id);// проверка на null

    }
}
