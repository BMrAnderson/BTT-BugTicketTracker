using BTT.Application.Services.Issues;
using BTT.Application.Services.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Application.Services.Projects
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public List<IssueDto> Issues { get; set; }
        public List<MemberDto> Members { get; set; }
        public Guid OrganizatonId { get; set; }
    }
}
