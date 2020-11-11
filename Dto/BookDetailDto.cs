using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProj.Dto
{
    public class BookDetailDto
    {
        public int BookId { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public DateTime DateIn { get; set; }

        public string Info { get; set; }

        public bool isHave { get; set; }

        public string Link { get; set; }
    }
}
