using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProj.Models
{
    public class Group
    {

        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public string CreatorName { get; set; }

        public List<Member> Members { get; set; }

        public string Avatar { get; set; }

        public string Description { get; set; }

        public List<BanMember> BanMembers { get; set; }





    }
}
