using AutoMapper;
using BTT.Application.Exceptions;
using BTT.Application.Services.Issues;
using BTT.Application.Services.Members;
using BTT.Domain.Common.Repository;
using BTT.Domain.Common.Specification;
using BTT.Domain.Contracts;
using BTT.Domain.Models.Issues;
using BTT.Domain.Models.Members;
using BTT.Domain.Models.Organizations;
using BTT.Domain.Models.Projects;
using System;

namespace BTT.Application.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> _projectRepository;
        private readonly IRepository<Member> _memberRepository;
        private readonly IRepository<Organization> _organizationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public ProjectService
            (IRepository<Project> projectRepository, 
             IRepository<Member> memberRepository, 
             IRepository<Organization> organizationRepository, 
             IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._projectRepository = projectRepository;
            this._memberRepository = memberRepository;
            this._organizationRepository = organizationRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public ProjectDto Add(ProjectDto projectDto)
        {
            Project project = _projectRepository.FindById(projectDto.Id);

            if (project != null)
                throw new ProjectAlreadyExistsException("This project already exists.");

            Organization organization = _organizationRepository.FindById(projectDto.OrganizatonId);

            if (organization is null)
                throw new OrganizationNotFoundException("Organization not found.");

            project = new Project(organization, projectDto.Title, projectDto.Description, projectDto.DueDate);

            _projectRepository.Add(project);

            _unitOfWork.Commit();

            return _mapper.Map<Project, ProjectDto>(project);
        }

        public MemberDto Add(Guid projectId, MemberDto memberDto)
        {
            Project existingProject = _projectRepository.FindById(projectId);

            if (existingProject is null)
                throw new ProjectNotFoundException("Project was not found.");

            Member newMember = new Member(memberDto.FirstName, memberDto.LastName, 
                memberDto.Email, memberDto.Password, existingProject.Organization);

            ProjectMember projectMember = new ProjectMember(existingProject, newMember);

            existingProject.AddProjectMember(projectMember);
            newMember.AddProject(projectMember);

            _projectRepository.Add(existingProject);
            _memberRepository.Add(newMember);

            _unitOfWork.Commit();

            return _mapper.Map<Member, MemberDto>(newMember);
        }

        public IssueDto Add(Guid memberId, Guid projectId, IssueDto issueDto)
        {
            Project existingProject = _projectRepository.FindById(projectId);

            if (existingProject is null)
                throw new ProjectNotFoundException("Project was not found.");

            Member existingMember = _memberRepository.FindById(memberId);

            if (existingMember is null)
                throw new MemberNotFoundException("Member was not found.");

            Issue newIssue = new Issue(existingMember, existingProject, issueDto.Title,
                issueDto.Description, issueDto.Priority, issueDto.EndDueDate);

            existingProject.AddProjectIssue(newIssue);

            _unitOfWork.Commit();

            return _mapper.Map<Issue, IssueDto>(newIssue);
        }

        public void Edit(ProjectDto projectDto)
        {
            ISpecification<Project> existingProject
                = new ProjectAlreadyExistsSpecification(projectDto.Id, projectDto.Title);

            Project project = _projectRepository.FindOne(existingProject);

            if (project is null)
                throw new ProjectNotFoundException("Project was not found.");

            project.ChangeDescription(projectDto.Description);
            project.ChangeName(projectDto.Title);
            project.ChangeDueDate(projectDto.DueDate);

            _unitOfWork.Commit();
        }

        public ProjectDto Get(Guid projectId)
        {
            Project existingProject = _projectRepository.FindById(projectId);

            if (existingProject is null)
                throw new ProjectNotFoundException("Project was not found.");

            return _mapper.Map<Project, ProjectDto>(existingProject);
        }

        public void Remove(Guid projectId)
        {
            Project existingProject = _projectRepository.FindById(projectId);

            if (existingProject is null)
                throw new ProjectNotFoundException("Project was not found.");

            _projectRepository.Remove(existingProject);

            _unitOfWork.Commit();
        }
    }
}