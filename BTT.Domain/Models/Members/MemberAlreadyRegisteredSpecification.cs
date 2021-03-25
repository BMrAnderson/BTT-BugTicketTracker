using BTT.Domain.Common.Specification;
using BTT.Domain.Models.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Members
{
    public class MemberAlreadyRegisteredSpecification : BaseSpecification<Member>
    {
        private string _email;

        public MemberAlreadyRegisteredSpecification(string email)
        {
            this._email = email;
        }

        public override Expression<Func<Member, bool>> SpecExpression
        {
            get => member => member.Email == _email;
                
        }
    }
}
