using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProj.Models;

namespace WebApiProj.Repositories
{
    public interface IGroupRepository
    {
        IEnumerable<Group> GetAll(); // получение всех объектов
        Group GetById(int id); // получение одного объекта по id
        void Create(Group item); // создание объекта
        void Update(Group item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
        bool Exists(int id);// проверка на null
        IEnumerable<Member> GetAllMembersOfGroup(int id); // получение всех участников группы
        IEnumerable<BanMember> GetAllBanMembersOfGroup(int id); // получение всех заблокированных участников группы
        void CreateMember(Member member); // создание объекта Member
        void CreateBanMember(BanMember member); // создание объекта BanMember
    }
}
