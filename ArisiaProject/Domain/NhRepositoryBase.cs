using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace ArisiaProject.Domain
{
    public abstract class NhRepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : Entity<TPrimaryKey>
    {
        #region Properties

        protected ISession Session
        {
            get { return NhUnitOfWork.Current.Session; }
        }

        #endregion

        #region Interface Method

        public void Insert(TEntity item)
        {
            Session.Save(item);
        }

        public void Update(TEntity item)
        {
            Session.Update(item);
        }

        public void Delete(TPrimaryKey itemId)
        {
            Session.Delete(Session.Load<TEntity>(itemId));
        }

        public TEntity GetById(TPrimaryKey itemId)
        {
            return Session.Get<TEntity>(itemId);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Session.Query<TEntity>();
        }

        #endregion
    }
}