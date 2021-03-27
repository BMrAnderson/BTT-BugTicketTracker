using BTT.Domain.Common.Repository;
using BTT.Domain.Common.Specification;
using BTT.Domain.Models.Organizations;
using BTT.Infrastructure.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace BTT.Infrastructure.Common.Repositories
{
    public class OrganizationRepository : IRepository<Organization>
    {
        private readonly EFRepository<Organization> _efOrganizationRepository;

        public OrganizationRepository(EFRepository<Organization> efOrganizationRepository)
        {
            this._efOrganizationRepository = efOrganizationRepository;
        }

        public void Add(Organization entity)
        {
            _efOrganizationRepository.Add(entity);
        }

        public IEnumerable<Organization> Find(ISpecification<Organization> spec)
        {
            return _efOrganizationRepository.Find(spec);
        }

        public Organization FindById(Guid id)
        {
            return _efOrganizationRepository.FindById(id);
        }

        public Organization FindOne(ISpecification<Organization> spec)
        {
            return _efOrganizationRepository.FindOne(spec);
        }

        public IEnumerable<Organization> GetAll()
        {
            return _efOrganizationRepository.GetAll();
        }

        public void Remove(Organization entity)
        {
            _efOrganizationRepository.Remove(entity);
        }
    }
}