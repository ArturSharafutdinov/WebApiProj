using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProj.Dto;
using WebApiProj.IServices;

namespace WebApiProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: api/Comments
        [HttpGet]
        public ActionResult<IEnumerable<CommentDto>> GetComments()
        {
            return _commentService.getAllComments().OrderBy(q => q.CommentId).ToList();
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public ActionResult<CommentDto> GetComment(int id)
        {
            return _commentService.getCommentById(id);
        }

        // GET: api/Comments/author
        [Route("author")]
        public ActionResult<IEnumerable<CommentDto>> GetCommentsByAuthor()
        {
            string author = HttpContext.Request.Query["name"];
            return _commentService.getAllCommentsFromAuthor(author).OrderBy(q => q.CommentId).ToList();
        }

        // PUT: api/Comments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutComment(int id, CommentDto commentDto)
        {
            commentDto.CommentId = id;
            _commentService.updateComment(commentDto);

            return NoContent();

        }

        // POST: api/Comments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<CommentDto> PostComment(CommentDto commentDto)
        {
            _commentService.addComment(commentDto);


            return NoContent();
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public ActionResult<CommentDto> DeleteComment(int id)
        {
            var comment = _commentService.getCommentById(id);
            if (comment == null)
            {
                return NotFound();
            }

            _commentService.removeComment(id);

            return comment;
        }

    }
}
