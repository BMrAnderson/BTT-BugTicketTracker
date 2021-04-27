using AutoMapper;
using BTT.Application.Exceptions;
using BTT.Domain.Common.Validation;
using BTT.Domain.Common.Repository;
using BTT.Domain.Common.Specification;
using BTT.Domain.Models.Issues;
using BTT.Domain.Models.Members;
using BTT.Domain.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BTT.Application.Services.Issues
{
    public class IssueService : IIssueService
    {
        private readonly IRepository<Issue> _issueRepository;
        private readonly IRepository<Member> _memberRepository;
        private readonly IRepository<Project> _projectRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IssueService(IRepository<Issue> issueRepository, IUnitOfWork unitOfWork, IMapper mapper, IRepository<Member> memberRepository, IRepository<Project> projectRepository)
        {
            this._issueRepository = issueRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._memberRepository = memberRepository;
            this._projectRepository = projectRepository;
        }

        public IssueDto Add(IssueDto issueDto)
        {
            Validation.CheckNull(issueDto, nameof(issueDto));

            var issue = _mapper.Map<IssueDto, Issue>(issueDto);

            _issueRepository.Add(issue);
          
            _unitOfWork.Commit();

            return issueDto;
        }

        public AttachmentDto AddAttachment(Guid issueId, AttachmentDto attachmentDto)
        {
            var issue = _issueRepository.FindById(issueId);

            Validation.CheckNull(issue, nameof(issue));

            Validation.CheckNull(attachmentDto, nameof(attachmentDto));

            var attachment = _mapper.Map<AttachmentDto, Attachment>(attachmentDto);

            issue.AddAttachment(attachment);

            _unitOfWork.Commit();

            return attachmentDto;
        }

        public CommentDto AddComment(Guid issueId, CommentDto commentDto)
        {
            var issue = _issueRepository.FindById(issueId);

            Validation.CheckNull(issue, nameof(issue));

            Validation.CheckNull(commentDto, nameof(commentDto));

            var comment = _mapper.Map<CommentDto, Comment>(commentDto);

            issue.AddComment(comment);

            _unitOfWork.Commit();

            return commentDto;
        }

        public void Edit(IssueDto issueDto)
        {
            if (issueDto == null)
                throw new IssueNotFoundException("No issue found.");

            if (issueDto.Id == Guid.Empty)
                throw new IssueNotFoundException($"No issue with such id was found.");

            Issue issue = _mapper.Map<IssueDto, Issue>(issueDto);

            issue.ChangeDescription(issueDto.Description);        
           
            issue.ChangeName(issueDto.Title);
            
            issue.ChangePriority(issueDto.Priority);
            
            issue.ChangeDueDate(issueDto.EndDueDate);

            _unitOfWork.Commit();
        }

        public IssueDto Get(Guid issueId)
        {
            var issue = _issueRepository.FindById(issueId);

            if (issue is null)
                throw new IssueNotFoundException($"Issue with the id: {issueId} was not found.");

            return _mapper.Map<Issue, IssueDto>(issue);
        }

        public IEnumerable<IssueDto> GetAllbyMemberId(Guid memberId)
        {
            var member = _memberRepository.FindById(memberId);

            if (member == null)
                throw new MemberNotFoundException($"Member with the id: {memberId} was not found.");

            return _mapper.Map<IEnumerable<Issue>, IEnumerable<IssueDto>>(member.Issues);
        }

        public IEnumerable<IssueDto> GetAllbyProjectId(Guid projectId)
        {
            var project = _projectRepository.FindById(projectId);

            if (project == null)
                throw new ProjectNotFoundException($"No project with the id: {projectId} was found.");

            return _mapper.Map<IEnumerable<Issue>, IEnumerable<IssueDto>>(project.Issues);
        }

        public IEnumerable<AttachmentDto> GetAttachments(Guid issueId)
        {
            var issue = _issueRepository.FindById(issueId);

            if (issue == null)
                throw new IssueNotFoundException($"No issue with the id: {issueId} was found.");

            return _mapper.Map<IEnumerable<Attachment>,IEnumerable<AttachmentDto>>(issue.Attachments);
        }

        public IEnumerable<CommentDto> GetComments(Guid issueId)
        {
            var issue = _issueRepository.FindById(issueId);

            if (issue == null)
                throw new IssueNotFoundException($"No issue with the id: {issueId} was found.");

            return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDto>>(issue.Comments);
        }

        public IssueDto Remove(Guid issueId)
        {
            var issue = _issueRepository.FindById(issueId);

            Validation.CheckCondition<IssueNotFoundException>
                (issue != null, $"No such issue with the id: {issueId} was found.");

            _issueRepository.Remove(issue);
           
            _unitOfWork.Commit();

            return _mapper.Map<Issue, IssueDto>(issue);
        }
    }
}