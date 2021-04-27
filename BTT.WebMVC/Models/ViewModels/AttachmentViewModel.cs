using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Models.ViewModels
{
    public class AttachmentViewModel
    {
        public Guid IssueId { get; set; }
        public string Filename { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public double Size { get; set; }
    }
}
