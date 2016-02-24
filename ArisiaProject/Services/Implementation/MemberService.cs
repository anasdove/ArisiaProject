using System;
using System.Collections.Generic;
using System.Linq;
using ArisiaProject.Domain;

namespace ArisiaProject.Services.Implementation
{
    public class MemberService : IMemberService
    {
        #region Declarations

        private readonly IMemberRepository _memberRepository;

        #endregion

        #region Constructor

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        #endregion

        #region IMemberService Method

        public List<Member> GetAllMember()
        {
            return _memberRepository.GetAll().ToList();
        }

        public void CreateMember(Member member)
        {
            _memberRepository.Insert(member);
        }

        public void UpdateMember(Member member)
        {
            _memberRepository.Update(member);
        }

        public void DeleteMember(Guid memberId)
        {
            _memberRepository.Delete(memberId);
        }

        #endregion
    }
}