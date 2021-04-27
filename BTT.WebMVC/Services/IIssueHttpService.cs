using BTT.WebMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Services
{
    public interface IIssueHttpService
    {
        Task<IssueViewModel> Get(Guid issueId);
        Task<bool> Add(IssueViewModel issueVM);
        Task<IEnumerable<IssueViewModel>> GetAllbyMemberId(Guid memberId);
        Task<IEnumerable<IssueViewModel>> GetAllbyProjectId(Guid projectId);
        Task<bool> AddAttachment(Guid issueId, AttachmentViewModel attachmentVM);
        Task<bool> AddComment(Guid issueId, CommentViewModel commentVM);
        Task<bool> Edit(IssueViewModel issueVM);
        Task<bool> Remove(Guid issueId);
    }
}
