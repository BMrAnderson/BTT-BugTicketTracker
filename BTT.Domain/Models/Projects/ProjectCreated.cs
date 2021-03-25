using BTT.Domain.Common.Events;
using BTT.Domain.Common.Extensions;
using System;

namespace BTT.Domain.Models.Projects
{
    public class ProjectCreated : IDomainEvent<Project>
    {
        public Guid EventId { get; }

        public DateTime EventDateOccured { get; }

        public Project Data { get; }

        public ProjectCreated(Project project)
        {
            project.CheckNull(nameof(project));

            this.Data = project;
            this.EventId = Guid.NewGuid();
            this.EventDateOccured = DateTime.Now;
        }
    }
}