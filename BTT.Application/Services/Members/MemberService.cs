using AutoMapper;
using BTT.Application.Exceptions;
using BTT.Application.Services.Projects;
using BTT.Domain.Common.Repository;
using BTT.Domain.Common.Specification;
using BTT.Domain.Models.Members;
using BTT.Domain.Models.Projects;
using System;

namespace BTT.Application.Services.Members
{
    public class MemberService : IMemberService
    {
        private readonly IRepository<Member> _memberRepository;
        private readonly IRepository<Project> _projectRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemberService(IRepository<Member> memberRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._memberRepository = memberRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public MemberDto Add(MemberDto memberDto)
        {
            ISpecification<Member> memberRegistered
                = new MemberAlreadyRegisteredSpecification(memberDto.Email);

            Member member = _memberRepository.FindOne(memberRegistered);

            if (member != null)
                throw new MemberAlreadyRegisteredException("A member with this email already exists.");

            member = new Member(memberDto.FirstName, memberDto.LastName,
                memberDto.Email, member.Password, member.Organization);

            _memberRepository.Add(member);

            _unitOfWork.Commit();

            return _mapper.Map<Member, MemberDto>(member);
        }

        public ProjectDto Add(Guid memberId, ProjectDto projectDto)
        {
            Member member = _memberRepository.FindById(memberId);

            if (member is null)
                throw new MemberNotFoundException("The member with this id was not found.");

            Project project = new Project(member.Organization,projectDto.Title,projectDto.Description,projectDto.DueDate);
            
            ProjectMember projectMember = new ProjectMember(project, member);
            
            project.AddProjectMember(projectMember);
            member.AddProject(projectMember);
           
            _projectRepository.Add(project);
            _memberRepository.Add(member);

            _unitOfWork.Commit();

            return _mapper.Map<Project, ProjectDto>(project);
        }

        public void Edit(MemberDto memberDto)
        {
            ISpecification<Member> memberExists
                = new MemberAlreadyRegisteredSpecification(memberDto.Email);

            Member member = _memberRepository.FindOne(memberExists);

            if (member is null)
                throw new MemberNotFoundException("No such member exists");

            member.ChangeEmail(memberDto.Email);

            _unitOfWork.Commit();
        }

        public bool EmailExists(string email)
        {
            ISpecification<Member> memberEmailExists
                = new MemberAlreadyRegisteredSpecification(email);

            Member member = _memberRepository.FindOne(memberEmailExists);

            return member != null;
        }

        public MemberDto Get(Guid memberId)
        {
            Member member = _memberRepository.FindById(memberId);

            if (member is null)
                throw new MemberNotFoundException("No such member was found.");

            return _mapper.Map<Member, MemberDto>(member);
        }

        public void Remove(Guid memberId)
        {
            Member member = _memberRepository.FindById(memberId);

            if (member is null)
                throw new MemberNotFoundException("No such member was found. Unable to delete.");

            _memberRepository.Remove(member);

            _unitOfWork.Commit();
        }
    }
}