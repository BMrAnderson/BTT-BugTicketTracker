using BTT.Domain.Models.Issues;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.WebMVC.Extensions.HTML
{
    public static class TableRowCategory
    {
        public static string SetBadgeColor(this IHtmlHelper helper, Priority priority)
        {
            var badgeStringBuilder = new StringBuilder("badge ");

            switch (priority)
            {
                case Priority.Low:
                    badgeStringBuilder.Append(" badge-success");
                    break;
                case Priority.Medium:
                    badgeStringBuilder.Append(" badge-warning");
                    break;
                case Priority.High:
                    badgeStringBuilder.Append(" badge-danger");
                    break;
            }
            return badgeStringBuilder.ToString();
        }
    }
}
