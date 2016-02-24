using System.Reflection;
using ArisiaProject.Domain;
using ArisiaProject.Helper;
using Castle.DynamicProxy;
using NHibernate;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

namespace ArisiaProject.UnitOfWork
{
    public class NhUnitOfWorkInterceptor : IInterceptor
    {
        #region Declarations

        private readonly ISessionFactory m_sessionFactory;

        #endregion

        #region Constructor

        public NhUnitOfWorkInterceptor(ISessionFactory sessionFactory)
        {
            m_sessionFactory = sessionFactory;
        }

        #endregion

        #region IInterceptor Members

        public void Intercept(IInvocation invocation)
        {
            if(NhUnitOfWork.Current != null || !RequiresDbConnection(invocation.MethodInvocationTarget)
            {
                invocation.Proceed();
                return;
            }

            try
            {
                NhUnitOfWork.Current = new NhUnitOfWork(m_sessionFactory);
                NhUnitOfWork.Current.BeginTransaction();

                try
                {
                    invocation.Proceed();
                    NhUnitOfWork.Current.Commit();
                }
                catch
                {
                    try
                    {
                        NhUnitOfWork.Current.Rollback();
                    }
                    catch
                    {

                    }

                    throw;
                }
            }
            finally
            {
                NhUnitOfWork.Current = null;
            }
        }

        #endregion

        #region Private Method

        private static bool RequiresDbConnection(MethodInfo methodInfo)
        {
            if (UnitOfWorkHelper.HasUnitOfWorkAttribute(methodInfo))
            {
                return true;
            }

            return UnitOfWorkHelper.IsRepositoryMethod(methodInfo);
        }

        #endregion
    }
}