using BTT.Domain.Common.Events;
using BTT.Domain.Common.Validation;
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
            Validation.CheckNull(project, nameof(project));

            this.Data = project;
            this.EventId = Guid.NewGuid();
            this.EventDateOccured = DateTime.Now;
        }
    }
}