using BTT.Domain.Models.Issues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Models.ViewModels
{
    public class IssueViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime EndDueDate { get; set; }
        public Priority Priority { get; set; }
        public List<CommentViewModel> Comments { get; set; }
        public List<AttachmentViewModel> Attachments { get; set; }
        public string AssignedMemberName { get; set; }
        public string AssignedProjectName { get; set; }
    }
}
