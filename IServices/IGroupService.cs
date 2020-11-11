using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProj.Dto;

namespace WebApiProj.IServices
{
    public interface IGroupService
    {

        public void addGroup(GroupDetailDto groupDto);


        public IEnumerable<GroupDto> getAllGroups();


        public GroupDetailDto getGroupById(int id);

        public void updateGroup(GroupDetailDto groupDto);

        public void removeGroup(int id);

    }
}
