using BTT.Application.Services.Organizations;
using Microsoft.AspNetCore.Mvc;
using System;
using BTT.Application.Services.Projects;
using BTT.Application.Services.Members;
using Microsoft.Extensions.Logging;

namespace BTT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;
        private readonly ILogger<OrganizationsController> _logger;

        public OrganizationsController(IOrganizationService organizationService, ILogger<OrganizationsController> logger)
        {
            this._organizationService = organizationService;
            this._logger = logger;
        }

        [HttpGet("o={organizationId}")]
        public IActionResult Get(Guid organizationId)
        {
            try
            {
               var org = _organizationService.Get(organizationId);
             
                if (org != null) return Ok(org);

                return NotFound(org);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody]string organizationName)
        {
            try
            {
                _organizationService.Add(organizationName);
                return Created($"/api/organizations/{organizationName}", organizationName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("o={organizationId}")]
        public IActionResult Add(Guid organizationId, [FromBody] ProjectDto projectDto)
        {
            try
            {
                var org = _organizationService.Get(organizationId);

                if (org != null)
                {
                    var project = _organizationService.Add(organizationId, projectDto);
                   
                    return Created($"/api/organizations/{organizationId}", projectDto);
                }
                return NotFound(organizationId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                
                return BadRequest();
            }
        }

        [HttpPost("o={organizationId}")]
        public IActionResult Add(Guid organizationId, [FromBody] MemberDto memberDto)
        {
            try
            {
                var org = _organizationService.Get(organizationId);

                if (org != null)
                {
                    var member = _organizationService.Add(organizationId, memberDto);

                    return Created($"/api/organizations/{organizationId}", memberDto);
                }
                return NotFound(org);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete("o={organizationId}")]
        public IActionResult Remove(Guid organizationId)
        {
            try
            {
                var org = _organizationService.Get(organizationId);

                if (org != null)
                {
                    _organizationService.Remove(organizationId);

                    return Ok(org);
                }
                return NotFound(organizationId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }

        }
    }
}