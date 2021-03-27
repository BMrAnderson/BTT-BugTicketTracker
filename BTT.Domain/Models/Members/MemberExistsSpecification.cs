using BTT.Domain.Common.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Members
{
    public class MemberExistsSpecification : BaseSpecification<Member>
    {
        private readonly Guid _memberId;

        public MemberExistsSpecification(Guid memberId)
        {
            this._memberId = memberId;
        }

        public override Expression<Func<Member, bool>> SpecExpression
        {
            get => member => member.Id == _memberId;
        }
    }
}
