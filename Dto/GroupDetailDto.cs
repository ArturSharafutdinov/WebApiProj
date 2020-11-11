using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProj.Dto
{
    public class GroupDetailDto
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public string CreatorName { get; set; }

        public string Avatar { get; set; }

        public string Description { get; set; }
    }
}
