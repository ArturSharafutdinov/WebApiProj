using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProj.Models
{
    public class Member
    {

        public int Id { get; set; }
        public string userName { get; set; }
        public int GroupId { get; set; }
        public string Role { get; set; }

        public Member(string userName, int groupId, string Role)
        {
            this.GroupId = groupId;
            this.userName = userName;
            this.Role = Role;
        }



    }
}
