using BTT.Domain.Common.Models;
using BTT.Domain.Common.Repository;
using BTT.Domain.Common.Specification;
using BTT.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BTT.Infrastructure.Domain.Repositories
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        private readonly IssueTicketTrackerDBContext _dbContext;
        private readonly DbSet<TEntity> _entities;

        public EFRepository(IssueTicketTrackerDBContext dbContext)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public IEnumerable<TEntity> Find(ISpecification<TEntity> spec)
        {
            return _entities.AsNoTracking().Where(spec.IsSatisfiedBy);
        }

        public TEntity FindById(Guid id)
        {
            return _entities.Find(id);
        }

        public TEntity FindOne(ISpecification<TEntity> spec)
        {
            return _entities.AsNoTracking().Where(spec.IsSatisfiedBy).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities.AsNoTracking<TEntity>();
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }
    }
}