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
    public class IssueService : IIssueViewModelService
    {
        private readonly IRepository<Issue> _issueRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IssueService(IRepository<Issue> issueRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._issueRepository = issueRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public IssueDto Add(IssueDto issueDto)
        {
            //Check if issue already exists.
            ISpecification<Issue> issueAlreadyExists = new IssueExistsSpecification(issueDto.Id);

            //If issue is found by specification then throw exception because the issue already exists.
            Issue existingIssue = _issueRepository.FindOne(issueAlreadyExists);

            if (existingIssue != null)
                throw new IssueAlreadyExistsException("Issue with the same title and description already exists in this project.");

            var issue = _mapper.Map<IssueDto, Issue>(issueDto);

            _issueRepository.Add(issue);
          
            _unitOfWork.Commit();

            return issueDto;
        }

        public AttachmentDto AddAttachment(Guid issueId, AttachmentDto attachmentDto)
        {
            var issue = _issueRepository.FindById(issueId);

            Validation.CheckNull(issue, nameof(issue));

            var attachment = _mapper.Map<AttachmentDto, Attachment>(attachmentDto);

            issue.AddAttachment(attachment);

            _unitOfWork.Commit();

            return attachmentDto;
        }

        public CommentDto AddComment(Guid issueId, CommentDto commentDto)
        {
            var issue = _issueRepository.FindById(issueId);

            Validation.CheckNull(issue, nameof(issue));

            var comment = _mapper.Map<CommentDto, Comment>(commentDto);

            issue.AddComment(comment);

            _unitOfWork.Commit();

            return commentDto;
        }

        public void Edit(IssueDto issueDto)
        {
            Validation.CheckCondition<IssueNotFoundException>(
                issueDto.Id != Guid.Empty,
                "Issue does not have a Id."
                );

            ISpecification<Issue> issueExistsSpec 
                = new IssueExistsInProjectSpecification(issueDto.ProjectId);

            Issue issue = _issueRepository.FindOne(issueExistsSpec);

            Validation.CheckCondition<IssueNotFoundException>(
                issue != null,
                "Issue not found."
                );

            issue.ChangeDescription(issueDto.Description);        
           
            issue.ChangeName(issueDto.Title);
            
            issue.ChangePriority(issueDto.Priority);
            
            issue.ChangeDueDate(issueDto.EndDueDate);

            _unitOfWork.Commit();
        }

        public IssueDto Get(Guid issueId)
        {
            ISpecification<Issue> issueExists = new IssueExistsSpecification(issueId);

            Issue issue = _issueRepository.FindOne(issueExists);

            if (issue is null)
                throw new IssueNotFoundException("Issue with this Id was not found.");

            return _mapper.Map<Issue, IssueDto>(issue);
        }

        public IEnumerable<IssueDto> GetAllbyMemberId(Guid memberId)
        {
            var member = _issueRepository.GetAll().Where(i => i.MemberId == memberId).FirstOrDefault();

            if (member == null)
                throw new MemberNotFoundException("Member was not found by this id");

            ISpecification<Issue> issuesByMember = new IssueByMemberSpecification(memberId);

            IEnumerable<Issue> issues = _issueRepository.Find(issuesByMember);

            if (issues == null)
                throw new IssueNotFoundException("No issues was found assigned for this member.");

            return _mapper.Map<IEnumerable<Issue>, IEnumerable<IssueDto>>(issues);
        }

        public IEnumerable<IssueDto> GetAllbyProjectId(Guid projectId)
        {
            ISpecification<Issue> issuesInProject = new IssueExistsInProjectSpecification(projectId);

            IEnumerable<Issue> issues = _issueRepository.Find(issuesInProject);

            if (issues is null)
                throw new IssueNotFoundException("No issues was found for this particular project.");

            return _mapper.Map<IEnumerable<Issue>, IEnumerable<IssueDto>>(issues);
        }

        public void Remove(Guid issueId)
        {
            ISpecification<Issue> issueExistsSpec = new IssueExistsSpecification(issueId);

            Issue issue = _issueRepository.FindOne(issueExistsSpec);

            if (issue is null)
                throw new IssueNotFoundException("No such issue was found");

            _issueRepository.Remove(issue);
           
            _unitOfWork.Commit();
        }
    }
}