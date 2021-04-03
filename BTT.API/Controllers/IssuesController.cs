using BTT.API.Models;
using BTT.Application.Exceptions;
using BTT.Application.Services.Issues;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BTT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly IIssueService _issueService;

        public IssuesController(IIssueService issueService)
        {
            this._issueService = issueService;
        }

        [HttpGet("i={issueId}")]
        public Response<IssueDto> Get(Guid issueId)
        {
            var result = new Response<IssueDto>();
            try
            {
                result.Result = new IssueDto()
                {
                    Id = Guid.NewGuid(),
                    Title = "Awe",
                    Description = "Test",
                    DateCreated = DateTime.Now,
                    EndDueDate = DateTime.Now.AddDays(1),
                    Priority = Domain.Models.Issues.Priority.High
                };
            }
            catch (Exception ex)
            {
                result.ExceptionType = ex.ToString();
                result.StackTrace = ex.StackTrace;
                result.Message = ex.Message;
            }
            return result;
        }

        // GET: api/issues/d49c3220-6f7b-45ec-982f-c4039de87b81
        [HttpGet("m={memberId}")]
        public Response<IEnumerable<IssueDto>> GetByMember(Guid memberId)
        {
            var result = new Response<IEnumerable<IssueDto>>();
            try
            {
                result.Result = _issueService.GetAllbyMemberId(memberId);
            }
            catch (MemberNotFoundException ex)
            {
                result.ExceptionType = ex.ToString();
                result.StackTrace = ex.StackTrace;
                result.Message = ex.Message;
            }
            return result;
        }

        // GET api/<IssuesController>/5
        [HttpGet("p={projectId}")]
        public Response<IEnumerable<IssueDto>> GetByProject(Guid projectId)
        {
            var result = new Response<IEnumerable<IssueDto>>();
            try
            {
                result.Result = _issueService.GetAllbyProjectId(projectId);
            }
            catch (Exception ex)
            {
                result.ExceptionType = ex.ToString();
                result.StackTrace = ex.StackTrace;
                result.Message = ex.Message;
            }
            return result;
        }

        // POST api/<IssuesController>
        [HttpPost]
        public Response<IssueDto> Add([FromBody] IssueDto issueDto)
        {
            var result = new Response<IssueDto>();
            try
            {
                _issueService.Add(issueDto);

                result.Message = "Submitted successfully";
            }
            catch (Exception ex)
            {
                result.ExceptionType = ex.ToString();
                result.StackTrace = ex.StackTrace;
                result.Message = ex.Message;
            }
            return result;
        }

        // PUT api/<IssuesController>/5
        [HttpPut]
        public ResponseMessage Update([FromBody] IssueDto issueDto)
        {
            var result = new ResponseMessage();
            try
            {
                _issueService.Edit(issueDto);

                result.Message = "Updated Successfully";
            }
            catch (Exception ex)
            {
                result.ExceptionType = ex.ToString();
                result.StackTrace = ex.StackTrace;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpPut("{issueId}")]
        public Response<AttachmentDto> Add(Guid issueId, [FromBody] AttachmentDto attachmentDto)
        {
            var result = new Response<AttachmentDto>();
            try
            {
                result.Result = _issueService.AddAttachment(issueId, attachmentDto);
            }
            catch (Exception ex)
            {
                result.ExceptionType = ex.ToString();
                result.StackTrace = ex.StackTrace;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpPut("{issueId}")]
        public Response<CommentDto> Add(Guid issueId, [FromBody] CommentDto commentDto)
        {
            var result = new Response<CommentDto>();
            try
            {
                result.Result = _issueService.AddComment(issueId, commentDto);
            }
            catch (Exception ex)
            {
                result.ExceptionType = ex.ToString();
                result.StackTrace = ex.StackTrace;
                result.Message = ex.Message;
            }
            return result;
        }


        // DELETE api/<IssuesController>/5
        [HttpDelete("{issueId}")]
        public ResponseMessage Delete(Guid issueId)
        {
            var result = new ResponseMessage();
            try
            {
                _issueService.Remove(issueId);

                result.Message = "Deleted successfully";
            }
            catch (Exception ex)
            {
                result.ExceptionType = ex.ToString();
                result.StackTrace = ex.StackTrace;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}