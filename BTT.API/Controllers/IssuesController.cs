using BTT.Application.Services.Issues;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BTT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly IIssueService _issueService;
        private readonly ILogger<IssuesController> _logger;

        public IssuesController(IIssueService issueService, ILogger<IssuesController> logger)
        {
            this._issueService = issueService;
            this._logger = logger;
        }

        [HttpGet("i={issueId}")]
        public IActionResult Get(Guid issueId)
        {
            try
            {
                var issue = _issueService.Get(issueId);
                if (issue != null) return Ok(issue);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
            return NotFound();
        }

        // GET: api/issues/d49c3220-6f7b-45ec-982f-c4039de87b81
        [HttpGet("m={memberId}")]
        public IActionResult GetByMember(Guid memberId)
        {
            try
            {
                var issues = _issueService.GetAllbyMemberId(memberId);
                if (issues != null) return Ok(issues);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
            return NotFound();
        }

        // GET api/<IssuesController>/5
        [HttpGet("p={projectId}")]
        public IActionResult GetByProject(Guid projectId)
        {
            try
            {
                var issues = _issueService.GetAllbyProjectId(projectId);
                if (issues != null) return Ok(issues);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
            return NotFound();
        }

        // POST api/<IssuesController>
        [HttpPost]
        public IActionResult Add([FromBody] IssueDto issueDto)
        {
            try
            {
                _issueService.Add(issueDto);
                return Created($"/api/issues/{issueDto.Id}", issueDto);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        // PUT api/<IssuesController>/5
        [HttpPut]
        public IActionResult Update([FromBody] IssueDto issueDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _issueService.Edit(issueDto);
                    return Ok(issueDto);
                }
                return StatusCode(304, issueDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpPut("{issueId}")]
        public IActionResult Add(Guid issueId, [FromBody] AttachmentDto attachmentDto)
        {
            try
            {
                var attachment = _issueService.AddAttachment(issueId, attachmentDto);
                if (attachment != null) return Created($"/api/issues/{issueId}", attachment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
            return BadRequest();
        }

        [HttpPut("{issueId}")]
        public IActionResult Add(Guid issueId, [FromBody] CommentDto commentDto)
        {
            try
            {
                var comment = _issueService.AddComment(issueId, commentDto);
                if (comment != null) return Created($"api/issues/{issueId}", comment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
            return BadRequest();
        }


        // DELETE api/<IssuesController>/5
        [HttpDelete("{issueId}")]
        public IActionResult Delete(Guid issueId)
        {
            try
            {
                var issue = _issueService.Remove(issueId);
                if (issue != null) return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
            return BadRequest();
        }
    }
}