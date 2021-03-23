using BTT.Domain.Common.Specification;
using BTT.Domain.Models.Members;
using BTT.Infrastructure.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Infrastructure.Common.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly EFRepository<Member> _efMemberRepository;

        public void Add(Member entity)
        {
            _efMemberRepository.Add(entity);
        }

        public IEnumerable<Member> Find(ISpecification<Member> spec)
        {
            return _efMemberRepository.Find(spec);
        }

        public Member FindById(Guid id)
        {
           return _efMemberRepository.FindById(id);
        }

        public Member FindOne(ISpecification<Member> spec)
        {
            return _efMemberRepository.FindOne(spec);
        }

        public IEnumerable<Member> GetAll()
        {
            return _efMemberRepository.GetAll();
        }

        public Member GetMemberByEmail(string email)
        {
            return _efMemberRepository.GetAll()
                .Where(m => m.Email == email).FirstOrDefault();
        }

        public void Remove(Member entity)
        {
            _efMemberRepository.Remove(entity);
        }
    }
}
