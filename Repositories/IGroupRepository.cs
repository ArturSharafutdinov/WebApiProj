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

        bool Exists(int id);

        IEnumerable<Member> GetAllMembersOfGroup(int id); // получение всех участников

        IEnumerable<BanMember> GetAllBanMembersOfGroup(int id); // получение всех объектов

        void CreateMember(Member member); // создание объекта

        void CreateBanMember(BanMember member); // создание объекта
    }
}
