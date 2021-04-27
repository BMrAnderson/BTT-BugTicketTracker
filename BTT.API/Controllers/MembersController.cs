using BTT.Application.Services.Members;
using BTT.Application.Services.Projects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace BTT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly ILogger<MembersController> _logger;

        public MembersController(IMemberService memberService, ILogger<MembersController> logger)
        {
            this._memberService = memberService;
            this._logger = logger;
        }

        [HttpGet("m={memberId}")]
        public IActionResult Get(Guid memberId)
        {
            try
            {
                var member = _memberService.Get(memberId);
                if (member != null) return Ok(member);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Add([FromBody] MemberDto memberDto)
        {
            try
            {
                _memberService.Add(memberDto);
                return Created($"/api/members/{memberDto.Id}", memberDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("m={memberId}")]
        public IActionResult Add(Guid memberId, [FromBody] ProjectDto projectDto)
        {
            try
            {
                var project = _memberService.Add(memberId, projectDto);
                if (project != null) return Created($"/api/projects/{memberId}", project);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
            return BadRequest();
        }

        [HttpDelete("m={memberId}")]
        public IActionResult Remove(Guid memberId)
        {
            try
            {
                _memberService.Remove(memberId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Update(MemberDto memberDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _memberService.Edit(memberDto);
                    return Ok(memberDto);
                }
                return StatusCode(304, memberDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult EmailExists(string email)
        {
            try
            {
                bool emailExists = _memberService.EmailExists(email);

                if (emailExists) return Ok(email);

                return NotFound(email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
    }
}