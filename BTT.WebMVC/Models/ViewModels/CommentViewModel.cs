using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Models.ViewModels
{
    public class CommentViewModel
    {
        public Guid IssueId { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
    }
}