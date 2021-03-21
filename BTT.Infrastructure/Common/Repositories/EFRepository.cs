using BTT.Domain.Common;
using BTT.Domain.Common.Models;
using BTT.Domain.Common.Repository;
using BTT.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Infrastructure.Domain.Repositories
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly IDbContext Context;

        private readonly DbSet<TEntity> _dbSet;

        public EFRepository(IDbContext dbContext)
        {
            this.Context = dbContext;

            _dbSet = dbContext != null ? Context.Set<TEntity>() 
                : throw new ArgumentNullException(nameof(dbContext));
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public TEntity FindById(Guid id)
        {
           return _dbSet.Find((object)id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking<TEntity>();
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
