using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProj.Dto;
using WebApiProj.IServices;
using WebApiProj.Models;
using WebApiProj.Repositories;

namespace WebApiProj.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRep;
        private readonly IMapper _mapper;
        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRep = commentRepository;
            _mapper = mapper;
        }


        public void addComment(CommentDto CommentDto)
        {
            var comment = _mapper.Map<Comment>(CommentDto);
            _commentRep.Create(comment);
            _commentRep.Save();
        }

        public IEnumerable<CommentDto> getAllComments()
        {
            return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDto>>(_commentRep.GetAll());
        }

        public CommentDto getCommentById(int id)
        {
            return _mapper.Map<CommentDto>(_commentRep.GetById(id));
        }

        public void updateComment(CommentDto CommentDto)
        {
            var comment = _mapper.Map<Comment>(CommentDto);
            _commentRep.Update(comment);
            _commentRep.Save();
        }

        public void removeComment(int id)
        {
            _commentRep.Delete(id);
            _commentRep.Save();
        }

        public IEnumerable<CommentDto> getAllCommentsFromAuthor(string author)
        {
            return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDto>>(_commentRep.GetAll()).Where(x=>x.Author.Equals(author));
        }

    }
}
