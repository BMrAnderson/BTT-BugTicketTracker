using BTT.Domain.Common.Repository;
using BTT.Domain.Models.Issues;
using BTT.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Infrastructure.Common.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        DbContext context;

        public EFUnitOfWork()
        {
            context = new IssueTicketTrackerDBContext();
        }

        public async Task<int> Commit()
        {
           return await context.SaveChangesAsync();
        }

        public ValueTask DisposeAsync()
        {
           return context.DisposeAsync();
        }

        public void RollBack()
        {
            context.Database.RollbackTransaction();
        }
    }
}
