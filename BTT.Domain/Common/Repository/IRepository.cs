using BTT.Domain.Common.Models;
using BTT.Domain.Common.Specification;
using System;
using System.Collections.Generic;

namespace BTT.Domain.Common.Repository
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        TEntity FindById(Guid id);

        IEnumerable<TEntity> GetAll();

        TEntity FindOne(ISpecification<TEntity> spec);

        IEnumerable<TEntity> Find(ISpecification<TEntity> spec);

        void Add(TEntity entity);

        void Remove(TEntity entity);
    }
}