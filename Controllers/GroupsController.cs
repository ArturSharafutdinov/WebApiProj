using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProj.Dto;
using WebApiProj.IServices;
using WebApiProj.Models;
using WebApiProj.Repositories;
using WebApiProj.Services;

namespace WebApiProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        // GET: api/Groups
        [HttpGet]
        public ActionResult<IEnumerable<GroupDto>> GetGroups()
        {
            return _groupService.getAllGroups().OrderBy(q => q.GroupId).ToList();
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public ActionResult<GroupDetailDto> GetGroup(int id)
        {
            return _groupService.getGroupById(id);
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutGroup(int id, GroupDetailDto groupDto)
        {
            groupDto.GroupId = id;
            _groupService.updateGroup(groupDto);

            return NoContent();

        }

        // POST: api/Groups
        [HttpPost]
        public ActionResult<GroupDetailDto> PostGroup(GroupDetailDto groupDto)
        {
            _groupService.addGroup(groupDto);


            return NoContent();
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public ActionResult<GroupDetailDto> DeleteGroup(int id)
        {
            var group = _groupService.getGroupById(id);
            if (group == null)
            {
                return NotFound();
            }

            _groupService.removeGroup(id);

            return group;
        }
        // POST: api/Groups/5
        [HttpPost("{id}")]
        public ActionResult<MemberDto> PostMember(int id,MemberDto memberDto)
        {
            _groupService.AddMemberToGroup(id, memberDto);

            return NoContent();
        }


        // api/Groups/members?id=5
        [Route("members")]
        public ActionResult<IEnumerable<MemberDto>> GetMembers()
        {
            int groupId = Convert.ToInt32(HttpContext.Request.Query["id"]);
            return _groupService.getAllMembers(groupId).ToList();
        }

    }
}
