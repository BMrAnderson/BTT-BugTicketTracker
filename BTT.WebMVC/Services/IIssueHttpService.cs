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
        IssueViewModel Get(Guid issueId);
        bool Add(IssueViewModel issueVM);
        IEnumerable<IssueViewModel> GetAllbyMemberId(Guid memberId);
        IEnumerable<IssueViewModel> GetAllbyProjectId(Guid projectId);
        bool AddAttachment(Guid issueId, AttachmentViewModel attachmentVM);
        bool AddComment(Guid issueId, CommentViewModel commentVM);
        bool Edit(IssueViewModel issueVM);
        bool Remove(Guid issueId);
    }
}
