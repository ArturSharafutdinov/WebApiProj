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
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRep;
        private readonly IMapper _mapper;
        public GroupService(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRep = groupRepository;
            _mapper = mapper;
        }


        public void addGroup(GroupDetailDto groupDto)
        {
            var group = _mapper.Map<Group>(groupDto);
            _groupRep.Create(group);
            _groupRep.Save();
        }

        public IEnumerable<GroupDto> getAllGroups()
        {
            return _mapper.Map<IEnumerable<Group>, IEnumerable<GroupDto>>(_groupRep.GetAll());
        }

        public GroupDetailDto getGroupById(int id)
        {
            return _mapper.Map<GroupDetailDto>(_groupRep.GetById(id));
        }

        public void updateGroup(GroupDetailDto groupDto)
        {
            var group = _mapper.Map<Group>(groupDto);
            _groupRep.Update(group);
            _groupRep.Save();
        }

        public void removeGroup(int id)
        {
            _groupRep.Delete(id);
            _groupRep.Save();
        }

        public IEnumerable<MemberDto> getAllMembers(int id)
        {
            return _mapper.Map<IEnumerable<Member>, IEnumerable<MemberDto>>(_groupRep.GetAllMembersOfGroup(id));
        }

        public IEnumerable<BanMemberDto> getAllBanMembers(int id)
        {
            return _mapper.Map<IEnumerable<BanMember>, IEnumerable<BanMemberDto>>(_groupRep.GetAllBanMembersOfGroup(id));
        }

        public void AddMemberToGroup(int id,MemberDto memberDto)
        {
            var member = _mapper.Map<Member>(memberDto);
            member.GroupId = id;
            _groupRep.CreateMember(member);
            _groupRep.Save();
        }

        public void AddBanMemberToGroup(int id,BanMemberDto memberDto)
        {
            var member = _mapper.Map<BanMember>(memberDto);
            member.GroupId = id;
            _groupRep.CreateBanMember(member);
            _groupRep.Save();
        }
    }
}
