using BTT.Application.Services.Issues;
using BTT.Application.Services.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Application.Services.Members
{
    public class MemberDto 
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<IssueDto> Issues { get; set; }
        public List<ProjectDto> Projects { get; set; }
        public Guid ProjectId { get; set; }
    }
}
