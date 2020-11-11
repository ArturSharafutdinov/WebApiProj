using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProj.Models
{
    public class BanMember
    {

        public int Id { get; set; }
        public string userName { get; set; }
        public int GroupId { get; set; }
        public string Reason { get; set; }

        public BanMember(string userName, int groupId, string Reason)
        {
            this.GroupId = groupId;
            this.userName = userName;
            this.Reason = Reason;
        }





    }
}
