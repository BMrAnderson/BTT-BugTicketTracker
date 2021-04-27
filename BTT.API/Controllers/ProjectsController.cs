
using BTT.Application.Services.Issues;
using BTT.Application.Services.Members;
using BTT.Application.Services.Projects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace BTT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly ILogger<ProjectsController> _logger;

        public ProjectsController(IProjectService projectService, ILogger<ProjectsController> logger)
        {
            this._projectService = projectService;
            this._logger = logger;
        }

        [HttpGet("p={projectId}")]
        public IActionResult Get(Guid projectId)
        {
            try
            {
                var project = _projectService.Get(projectId);
                
                if (project != null) return Ok(project);

                return NotFound(project);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProjectDto projectDto)
        {
            try
            {
                var project = _projectService.Add(projectDto);

                if (project != null) return Ok(project);

                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }

        }

        [HttpPost("p={projectId}")]
        public IActionResult Add(Guid projectId, [FromBody] MemberDto memberDto)
        {
            try
            {
                var project = _projectService.Get(projectId);

                if (project != null)
                {
                    _projectService.Add(projectId, memberDto);

                    return Ok(memberDto);
                }
                return NotFound(project);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("m={memberId}/p={projectId}")]
        public IActionResult Add(Guid memberId, Guid projectId, [FromBody] IssueDto issueDto)
        {
            try
            {
                _projectService.Add(memberId, projectId, issueDto);
                return Ok(issueDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpPut("p={projectId}")]
        public IActionResult Update([FromBody] ProjectDto projectDto)
        {
            try
            {
                var project = _projectService.Get(projectDto.Id);

                if (project != null)
                {
                    _projectService.Edit(projectDto);

                    return Ok(projectDto);
                }
                return StatusCode(304, projectDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete("p={projectId}")]
        public IActionResult Remove(Guid projectId)
        {
            try
            {
                _projectService.Remove(projectId);
                return Ok(projectId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

    }
}