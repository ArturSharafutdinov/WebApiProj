using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProj.Dto;
using WebApiProj.Models;

namespace WebApiProj.IServices
{
    public interface IGroupService
    {

        public void addGroup(GroupDetailDto groupDto);


        public IEnumerable<GroupDto> getAllGroups();


        public GroupDetailDto getGroupById(int id);

        public void updateGroup(GroupDetailDto groupDto);

        public void removeGroup(int id);

        public IEnumerable<MemberDto> getAllMembers(int id);


        public IEnumerable<BanMemberDto> getAllBanMembers(int id);

        public void AddMemberToGroup(int id,MemberDto memberDto);

        public void AddBanMemberToGroup(int id,BanMemberDto memberDto);


    }
}
