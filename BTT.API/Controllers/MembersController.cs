using BTT.API.Models;
using BTT.Application.Services.Members;
using BTT.Application.Services.Projects;
using BTT.API.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BTT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            this._memberService = memberService;
        }

        [HttpGet("{memberId}")]
        public Response<MemberDto> Get(Guid memberId)
        {
            var result = new Response<MemberDto>();
            try
            {
                result.Result = _memberService.Get(memberId);
            }
            catch (Exception ex)
            {
                result = ex.SanitizeException<MemberDto>();
            }
            return result;
        }

        [HttpPost]
        public Response<MemberDto> Add([FromBody]MemberDto memberDto)
        {
            var result = new Response<MemberDto>();
            try
            {
                result.Result = _memberService.Add(memberDto);
                result.Message = "Successfully added Member";
            }
            catch (Exception ex)
            {
                result = ex.SanitizeException<MemberDto>();
            }
            return result;
        }

        [HttpPost("{memberId}")]
        public Response<ProjectDto> Add(Guid memberId,[FromBody]ProjectDto projectDto)
        {
            var result = new Response<ProjectDto>();
            try
            {
                result.Result = _memberService.Add(memberId, projectDto);
                result.Message = "Successfully added project.";
            }
            catch (Exception ex)
            {
                result = ex.SanitizeException<ProjectDto>();
            }
            return result;
        }

        [HttpDelete("{memberId}")]
        public ResponseMessage Remove(Guid memberId)
        {
            var result = new ResponseMessage();
            try
            {
                _memberService.Remove(memberId);
                result.Message = "Successfully Removed Member";
            }
            catch (Exception ex)
            {
                result = ex.SanitizeException();
            }
            return result;
        }

        [HttpPut]
        public ResponseMessage Update(MemberDto memberDto)
        {
            var result = new ResponseMessage();
            try
            {
                _memberService.Edit(memberDto);
                result.Message = "Updated member Successfully";
            }
            catch (Exception ex)
            {
                result = ex.SanitizeException();
            }
            return result;
        }

        [HttpGet]
        public ResponseMessage EmailExists(string email)
        {
            var result = new ResponseMessage();
            try
            {
                _memberService.EmailExists(email);
                result.Message = "Email found.";
            }
            catch (Exception ex)
            {
                result = ex.SanitizeException();
            }
            return result;
        }
    }
}