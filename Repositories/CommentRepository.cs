using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProj.Models;

namespace WebApiProj.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private CommentsContext db;
        public CommentRepository(CommentsContext CommentsContext)
        {
            db = CommentsContext;
        }

        public void Create(Comment item)
        {
            db.Add(item);
        }

        public void Delete(int id)
        {
            db.Remove(db.Comments.Find(id));
        }


        public Comment GetById(int id)
        {
            return db.Comments.Find(id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return db.Comments.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Comment item)
        {
            db.Comments.Update(item);
        }

        public bool Exists(int id)
        {
            return GetById(id) != null;
        }
    }
}
