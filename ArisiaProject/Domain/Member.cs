using System;

namespace ArisiaProject.Domain
{
    public class Member : Entity<Guid>
    {
        #region Properties

        public virtual string Name { get; set; }

        public virtual DateTime BirthOfDate { get; set; }

        public virtual string Grade { get; set; }

        // Component
        public virtual Address Address { get; set; }

        #endregion
    }
}