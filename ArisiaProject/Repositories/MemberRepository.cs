using System;
using System.Collections.Generic;
using System.Linq;
using ArisiaProject.Domain;

namespace ArisiaProject.Repositories
{
    public class MemberRepository : NhRepositoryBase<Member, Guid>, IMemberRepository
    {
        #region IMemberRepository Method

        public IEnumerable<Member> GetByGrade(string grade)
        {
            return GetAll().Where(m => m.Grade == grade);
        }

        #endregion
    }
}