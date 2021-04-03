using BTT.API.Models;
using BTT.Application.Services.Organizations;
using BTT.API.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using BTT.Application.Services.Projects;
using BTT.Application.Services.Members;

namespace BTT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationsController(IOrganizationService organizationService)
        {
            this._organizationService = organizationService;
        }

        [HttpGet("{organizationId}")]
        public Response<OrganizationDto> Get(Guid organizationId)
        {
            var result = new Response<OrganizationDto>();
            try
            {
               result.Result = _organizationService.Get(organizationId);
            }
            catch (Exception ex)
            {
               result = ex.SanitizeException<OrganizationDto>();
            }
            return result;
        }

        [HttpPost]
        public Response<OrganizationDto> Add([FromBody]string organizationName)
        {
            var result = new Response<OrganizationDto>();
            try
            {
                result.Result = _organizationService.Add(organizationName);
                result.Message = "Organization added";
            }
            catch (Exception ex)
            {
                result = ex.SanitizeException<OrganizationDto>();
            }
            return result;
        }

        [HttpPost("{organizationId}")]
        public Response<ProjectDto> Add(Guid organizationId, ProjectDto projectDto)
        {
            var result = new Response<ProjectDto>();
            try
            {
                result.Result = _organizationService.Add(organizationId, projectDto);
                result.Message = "Project added to the organization.";
            }
            catch (Exception ex)
            {
                result = ex.SanitizeException<ProjectDto>();
            }
            return result;
        }

        [HttpPost("{organizationId}")]
        public Response<MemberDto> Add(Guid organizationId, [FromBody] MemberDto memberDto)
        {
            var result = new Response<MemberDto>();
            try
            {
                result.Result = _organizationService.Add(organizationId, memberDto);
                result.Message = "Member added to the organization.";
            }
            catch (Exception ex)
            {
                result = ex.SanitizeException<MemberDto>();
            }
            return result;
        }

        [HttpDelete("{organizationId}")]
        public ResponseMessage Remove(Guid organizationId)
        {
            var result = new ResponseMessage();
            try
            {
                _organizationService.Remove(organizationId);
                result.Message = "Organization successfully removed.";
            }
            catch (Exception ex)
            {
               result = ex.SanitizeException();
            }
            return result;
        }
    }
}