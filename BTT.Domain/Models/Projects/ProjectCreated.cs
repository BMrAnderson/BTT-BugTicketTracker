using BTT.Domain.Common.Events;
using BTT.Domain.Common.Validation;
using System;

namespace BTT.Domain.Models.Projects
{
    public class ProjectCreated : IDomainEvent
    {
        public Guid EventId { get; }

        public DateTime EventDateOccured { get; }

        public Project Project { get; }

        public ProjectCreated(Project project)
        {
            Validation.CheckNull(project, nameof(project));

            this.Project = project;
            this.EventId = Guid.NewGuid();
            this.EventDateOccured = DateTime.Now;
        }
    }
}