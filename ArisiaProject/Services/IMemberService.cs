using System;
using System.Collections.Generic;
using ArisiaProject.Domain;

namespace ArisiaProject.Services
{
    public interface IMemberService
    {
        List<Member> GetAllMember();
        void CreateMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(Guid memberId);
    }
}
