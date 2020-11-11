using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProj.Models;

namespace WebApiProj.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private GroupsContext db;
        public GroupRepository(GroupsContext groupContext)
        {
            db = groupContext;
        }

        public void Create(Group item)
        {
            db.Add(item);
        }

        public void Delete(int id)
        {
            db.Remove(db.Groups.Find(id));
        }


        public Group GetById(int id)
        {
            return db.Groups.Find(id);
        }

        public IEnumerable<Group> GetAll()
        {
            return db.Groups.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Group item)
        {
            db.Groups.Update(item);
        }

        public bool Exists(int id)
        {
            return GetById(id) != null;
        }
    }
}
