using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProj.Dto;

namespace WebApiProj.IServices
{
    public interface ICommentService
    {
        public void addComment(CommentDto commentDto);
        public IEnumerable<CommentDto> getAllComments();
        public CommentDto getCommentById(int id);
        public void updateComment(CommentDto commentDto);
        public void removeComment(int id);
        public IEnumerable<CommentDto> getAllCommentsFromAuthor(string author);
    }
}
