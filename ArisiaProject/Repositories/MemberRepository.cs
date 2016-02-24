using System;
using System.Collections.Generic;
using System.Linq;
using ArisiaProject.Domain;
using NHibernate.Criterion;

namespace ArisiaProject.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        #region Interface Method

        public void Add(Member item)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(item);
                    transaction.Commit();
                }
            }
        }

        public void Add(ICollection<Member> items)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                foreach (var item in items)
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Save(item);
                        transaction.Commit();
                    }
                }
            }
        }

        public void Update(Member item)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(item);
                    transaction.Commit();
                }
            }
        }

        public void Update(ICollection<Member> items)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                foreach (var item in items)
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Update(item);
                        transaction.Commit();
                    }
                }
            }
        }

        public void Remove(Member item)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(item);
                    transaction.Commit();
                }
            }
        }

        public void Remove(ICollection<Member> items)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                foreach (var item in items)
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Delete(item);
                        transaction.Commit();
                    }
                }
            }
        }

        public Member GetById(Guid itemId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var createCriteria = session.CreateCriteria(typeof (Member));

                createCriteria.Add(Restrictions.Eq("ID", itemId));

                var results = createCriteria.List<Member>();

                return results.FirstOrDefault();
            }
        }

        public Member GetByName(string name)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var createCriteria = session.CreateCriteria(typeof(Member));

                createCriteria.Add(Restrictions.Eq("Name", name));

                var results = createCriteria.List<Member>();

                return results.FirstOrDefault();
            }
        }

        public ICollection<Member> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var createCriteria = session.CreateCriteria(typeof(Member));

                return createCriteria.List<Member>();
            }
        }

        public ICollection<Member> GetByGrade(string grade)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var createCriteria = session.CreateCriteria(typeof(Member));

                createCriteria.Add(Restrictions.Eq("Grade", grade));

                return createCriteria.List<Member>();
            }
        }

        #endregion
    }
}