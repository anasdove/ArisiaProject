using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArisiaProject.Domain
{
    public interface IMemberRepository : IRepository<Member>
    {
        ICollection<Member> GetByGrade(string grade);
    }
}
