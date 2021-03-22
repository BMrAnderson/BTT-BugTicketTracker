using BTT.Domain.Common.Events;
using System;

namespace BTT.Domain.Models.Projects
{
    public class ProjectCreated : IDomainEvent
    {
        public Guid EventId { get; }

        public DateTimeOffset EventDateOccured { get; }

        public Project Project { get; }

        public ProjectCreated(Project project)
        {
            this.Project = project;
            this.EventId = Guid.NewGuid();
            this.EventDateOccured = DateTimeOffset.Now;
        }
    }
}