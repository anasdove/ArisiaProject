using System;
using System.Collections.Generic;

namespace ArisiaProject.Domain
{
    public interface IMemberRepository : IRepository<Member, Guid>
    {
        IEnumerable<Member> GetByGrade(string grade);
    }
}
