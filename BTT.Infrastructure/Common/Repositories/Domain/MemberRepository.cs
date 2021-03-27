using BTT.Domain.Common.Repository;
using BTT.Domain.Common.Specification;
using BTT.Domain.Models.Members;
using BTT.Infrastructure.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace BTT.Infrastructure.Common.Repositories
{
    public class MemberRepository : IRepository<Member>
    {
        private readonly EFRepository<Member> _efMemberRepository;

        public MemberRepository(EFRepository<Member> memberRepository)
        {
            this._efMemberRepository = memberRepository;
        }

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

        public void Remove(Member entity)
        {
            _efMemberRepository.Remove(entity);
        }
    }
}