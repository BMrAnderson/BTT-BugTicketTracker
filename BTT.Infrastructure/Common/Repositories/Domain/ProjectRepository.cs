using BTT.Domain.Common.Repository;
using BTT.Domain.Common.Specification;
using BTT.Domain.Models.Projects;
using BTT.Infrastructure.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Infrastructure.Common.Repositories
{
    public class ProjectRepository : IRepository<Project>
    {
        private readonly EFRepository<Project> _efProjectRepository;

        public void Add(Project entity)
        {
            _efProjectRepository.Add(entity);
        }

        public IEnumerable<Project> Find(ISpecification<Project> spec)
        {
            return _efProjectRepository.Find(spec);
        }

        public Project FindById(Guid id)
        {
            return _efProjectRepository.FindById(id);
        }

        public Project FindOne(ISpecification<Project> spec)
        {
            return _efProjectRepository.FindOne(spec);
        }

        public IEnumerable<Project> GetAll()
        {
            return _efProjectRepository.GetAll();
        }

        public void Remove(Project entity)
        {
            _efProjectRepository.Remove(entity);
        }
    }
}
