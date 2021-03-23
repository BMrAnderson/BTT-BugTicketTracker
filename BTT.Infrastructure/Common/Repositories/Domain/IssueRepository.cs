using BTT.Domain.Common.Specification;
using BTT.Domain.Models.Issues;
using BTT.Infrastructure.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Infrastructure.Common.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        private readonly EFRepository<Issue> _efIssueRepo;

        public IssueRepository(EFRepository<Issue> efIssueRepo)
        {
            this._efIssueRepo = efIssueRepo;
        }

        public void Add(Issue entity)
        {
            _efIssueRepo.Add(entity);
        }

        public IEnumerable<Issue> Find(ISpecification<Issue> spec)
        {
            return _efIssueRepo.Find(spec);
        }

        public Issue FindById(Guid id)
        {
            return _efIssueRepo.FindById(id);
        }

        public Issue FindOne(ISpecification<Issue> spec)
        {
            return _efIssueRepo.FindOne(spec);
        }

        public IEnumerable<Issue> GetAll()
        {
            return _efIssueRepo.GetAll();
        }

        public IEnumerable<Issue> GetIssuesByProjectId(Guid id)
        {
            return _efIssueRepo.GetAll().Where(i => i.ProjectId == id);
        }

        public void Remove(Issue entity)
        {
            _efIssueRepo.Remove(entity);
        }
    }
}
