using System;
using NHibernate;

namespace ArisiaProject.Domain
{
    public class NhUnitOfWork : IUnitOfWork
    {
        #region Declarations

        [ThreadStatic]
        private static NhUnitOfWork _current;
        private readonly ISessionFactory _sessionFactory;
        private ITransaction _transaction;

        #endregion

        #region Constructor

        public NhUnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        #endregion

        #region Properties

        public static NhUnitOfWork Current
        {
            get { return _current; }
            set { _current = value; }
        }

        public ISession Session { get; private set; }

        #endregion

        #region Interface Method

        /// <summary>
        /// Opens database connection and begins transaction.
        /// </summary>
        public void BeginTransaction()
        {
            Session = _sessionFactory.OpenSession();
            _transaction = Session.BeginTransaction();
        }

        /// <summary>
        /// Commits transaction and closes database connection.
        /// </summary>
        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            finally
            {
                Session.Close();
            }
        }

        /// <summary>
        /// Rollbacks transaction and closes database connection.
        /// </summary>
        public void Rollback()
        {
            try
            {
                _transaction.Rollback();
            }
            finally
            {
                Session.Close();
            }
        }

        #endregion
    }
}