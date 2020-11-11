using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProj.Dto
{
    public class CommentDto
    {
        public int CommentId { get; set; }

        public string CommentText { get; set; }

        public string Author { get; set; }

    }
}
