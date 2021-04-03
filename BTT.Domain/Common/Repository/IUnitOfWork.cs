using BTT.Domain.Models.Issues;
using BTT.Domain.Models.Members;
using BTT.Domain.Models.Organizations;
using BTT.Domain.Models.Projects;
using System;
using System.Threading.Tasks;

namespace BTT.Domain.Common.Repository
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IIssueRepository Issues { get; }
        IOrganizationRepository Organizations { get; }
        IMemberRepository Members { get; }
        IProjectRepository Projects { get; }

        Task<int> Commit();
    }
}