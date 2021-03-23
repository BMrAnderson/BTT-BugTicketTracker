using System;
using System.Threading.Tasks;

namespace BTT.Domain.Common.Repository
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task<int> Commit();
        void RollBack();
    }
}