using AutoMapper;
using BTT.Application.Exceptions;
using BTT.Application.Services.Members;
using BTT.Application.Services.Projects;
using BTT.Domain.Common.Repository;
using BTT.Domain.Common.Specification;
using BTT.Domain.Models.Members;
using BTT.Domain.Models.Organizations;
using BTT.Domain.Models.Projects;
using System;


namespace BTT.Application.Services.Organizations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IRepository<Organization> _organizationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public OrganizationService(IRepository<Organization> organizationRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._organizationRepository = organizationRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public OrganizationDto Add(string organizationName)
        {
            ISpecification<Organization> organizationExists
                = new OrganizationExistsByNameSpecification(organizationName);

            Organization organization = _organizationRepository.FindOne(organizationExists);

            if (organization != null)
                throw new OrganizationAlreadyExistsException("An organization with this name already exists.");

            organization = new Organization(organizationName);

            _organizationRepository.Add(organization);

            _unitOfWork.Commit();

            return _mapper.Map<Organization, OrganizationDto>(organization);
        }

        public ProjectDto Add(Guid organizationId, ProjectDto projectDto)
        {
            ISpecification<Organization> organizationExists
                 = new OrganizationExistsSpecification(organizationId);

            Organization organization = _organizationRepository.FindOne(organizationExists);

            if (organization is null)
                throw new OrganizationNotFoundException("The Organization with this Id was not found.");

            Project project = _mapper.Map<ProjectDto, Project>(projectDto);

            organization.AddOrganizationProject(project);

            _unitOfWork.Commit();

            return projectDto;
        }

        public MemberDto Add(Guid organizationId, MemberDto memberDto)
        {
            ISpecification<Organization> organizationExists
                = new OrganizationExistsSpecification(organizationId);

            Organization organization = _organizationRepository.FindOne(organizationExists);

            if (organization is null)
                throw new OrganizationNotFoundException("The Organization with this Id was not found.");

            Member member = _mapper.Map<MemberDto, Member>(memberDto);

            organization.AddOrganizationMember(member);

            _unitOfWork.Commit();

            return memberDto;
        }

        public OrganizationDto Get(Guid organizationId)
        {
            ISpecification<Organization> organizationExists
                = new OrganizationExistsSpecification(organizationId);

            Organization organization = _organizationRepository.FindOne(organizationExists);

            if (organization is null)
                throw new OrganizationNotFoundException("The Organization with this Id was not found.");

            return _mapper.Map<Organization, OrganizationDto>(organization);
        }

        public void Remove(Guid organizationId)
        {
            ISpecification<Organization> organizationExists
               = new OrganizationExistsSpecification(organizationId);

            Organization organization = _organizationRepository.FindOne(organizationExists);

            if (organization is null)
                throw new OrganizationNotFoundException("The Organization with this Id was not found.");

            _organizationRepository.Remove(organization);

            _unitOfWork.Commit();
        }
    }
}