using BTT.Domain.Models.Issues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Projects
{
    public class ProjectIssue
    {
        public Guid ProjectId { get; }

        public Guid IssueId { get; }

        public ProjectIssue(Project project, Issue issue)
        {
            this.IssueId = issue.Id;
            this.ProjectId = project.Id;
        }
    }
}
