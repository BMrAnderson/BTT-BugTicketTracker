using System;

namespace BTT.Application.Services.Issues
{
    public interface IIssueService
    {
        IssueDto Get(Guid issueId);
        IssueDto Add(IssueDto issueDto);
        AttachmentDto Add(Guid issueId, AttachmentDto attachment);
        CommentDto Add(Guid issueId, CommentDto comment);
        void Edit(IssueDto issueDto);
        void Remove(Guid issueId);

    }
}