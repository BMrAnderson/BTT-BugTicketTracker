using System;
using System.Collections.Generic;

namespace BTT.Domain.Common.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity FindById(Guid id);

        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);

        void Remove(TEntity entity);
    }
}