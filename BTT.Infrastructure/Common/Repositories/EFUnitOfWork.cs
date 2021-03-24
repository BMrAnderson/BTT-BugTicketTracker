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
        private readonly IssueTicketTrackerDBContext _context; 

        public EFUnitOfWork(IssueTicketTrackerDBContext context)
        {
            _context = context;
        }

        public async Task<int> Commit()
        {
           return await _context.SaveChangesAsync();
        }

        public ValueTask DisposeAsync()
        {
           return _context.DisposeAsync();
        }

        public void RollBack()
        {
            _context.Database.RollbackTransaction();
        }
    }
}
