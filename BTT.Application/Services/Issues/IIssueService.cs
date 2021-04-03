using System;
using System.Collections;
using System.Collections.Generic;

namespace BTT.Application.Services.Issues
{
    public interface IIssueService
    {
        IssueDto Get(Guid issueId);
        bool Add(IssueDto issueDto);
        IEnumerable<IssueDto> GetAllbyMemberId(Guid memberId);
        IEnumerable<IssueDto> GetAllbyProjectId(Guid projectId);
        AttachmentDto AddAttachment(Guid issueId, AttachmentDto attachment);
        CommentDto AddComment(Guid issueId, CommentDto comment);
        void Edit(IssueDto issueDto);
        void Remove(Guid issueId);
    }
}