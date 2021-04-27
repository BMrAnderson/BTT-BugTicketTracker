﻿
using BTT.Application.Services.Issues;
using BTT.Application.Services.Members;
using BTT.Application.Services.Projects;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BTT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            this._projectService = projectService;
        }

        //[HttpGet("p={projectId}")]
        //public Response<ProjectDto> Get(Guid projectId)
        //{
        //    var result = new Response<ProjectDto>();
        //    try
        //    {
        //        result.Data = _projectService.Get(projectId);
        //    }
        //    catch (Exception ex)
        //    {
        //        result = ex.SanitizeException<ProjectDto>();
        //    }
        //    return result;
        //}

        //[HttpPost]
        //public Response<ProjectDto> Add([FromBody]ProjectDto projectDto)
        //{
        //    var result = new Response<ProjectDto>();
        //    try
        //    {
        //        result.Data = _projectService.Add(projectDto);
        //        result.Message = "Project successfully added";
        //    }
        //    catch (Exception ex)
        //    {
        //        result = ex.SanitizeException<ProjectDto>();
        //    }
        //    return result;
        //}

        //[HttpPost("p={projectId}")]
        //public Response<MemberDto> Add(Guid projectId,[FromBody] MemberDto memberDto)
        //{
        //    var result = new Response<MemberDto>();
        //    try
        //    {
        //        result.Data = _projectService.Add(projectId, memberDto);
        //        result.Message = "Member succesfully added to the project";
        //    }
        //    catch (Exception ex)
        //    {
        //        result = ex.SanitizeException<MemberDto>();
        //    }
        //    return result;
        //}

        //[HttpPost("m={memberId}/p={projectId}")]
        //public Response<IssueDto> Add(Guid memberId, Guid projectId,[FromBody] IssueDto issueDto)
        //{
        //    var result = new Response<IssueDto>();
        //    try
        //    {
        //        result.Data = _projectService.Add(memberId, projectId, issueDto);
        //        result.Message = "Issue successfully added to the project";
        //    }
        //    catch (Exception ex)
        //    {
        //        result = ex.SanitizeException<IssueDto>();
        //    }
        //    return result;
        //}

        //[HttpPut("p={projectId}")]
        //public ResponseMessage Update(Guid projectId,[FromBody] MemberDto memberDto)
        //{
        //    var result = new Response<MemberDto>();
        //    try
        //    {
        //        result.Data = _projectService.Add(projectId, memberDto);
        //        result.Message = "Member successfully added to the project";
        //    }
        //    catch (Exception ex)
        //    {
        //        result = ex.SanitizeException<MemberDto>();
        //    }
        //    return result;
        //}

        //[HttpDelete("p={projectId}")]
        //public ResponseMessage Remove(Guid projectId)
        //{
        //    var result = new ResponseMessage();
        //    try
        //    {
        //         _projectService.Remove(projectId);
        //        result.Message = "Project deleted.";
        //    }
        //    catch (Exception ex)
        //    {
        //        result = ex.SanitizeException();
        //    }
        //    return result;
        //}

    }
}