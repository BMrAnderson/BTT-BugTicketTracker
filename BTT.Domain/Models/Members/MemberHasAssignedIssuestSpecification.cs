using BTT.Domain.Common.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Members
{
    public class MemberHaveAssignedIssuesSpecification : BaseSpecification<Member>
    {
        public override Expression<Func<Member, bool>> SpecExpression
        {
            get => member => member.Issues.Count != 0;
        }
    }
}
