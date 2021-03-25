using BTT.Domain.Common.Specification;
using BTT.Domain.Models.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Issues
{
    public class IssueByMemberSpecification : BaseSpecification<Issue>
    {
        private Guid _memberId;

        public IssueByMemberSpecification(Guid memberId)
        {
            this._memberId = memberId;
        }

        public override Expression<Func<Issue, bool>> SpecExpression
        {
            get => issue => issue.MemberId == _memberId;
        }
    }
}
