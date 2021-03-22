using BTT.Domain.Common.Repository;

namespace BTT.Domain.Models.Members
{
    public interface IMemberRepository : IRepository<Member>
    {
        Member GetMemberByEmail(string email);
    }
}