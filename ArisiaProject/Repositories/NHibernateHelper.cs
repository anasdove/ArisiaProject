using ArisiaProject.Domain;
using NHibernate;
using NHibernate.Cfg;

namespace ArisiaProject.Repositories
{
    public class NHibernateHelper
    {
        #region Declarations

        private static ISessionFactory _sessionFactory;

        #endregion

        #region Properties

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory != null)
                {
                    return _sessionFactory;
                }

                var config = new Configuration();
                config.Configure();

                config.AddAssembly(typeof (Member).Assembly);

                _sessionFactory = config.BuildSessionFactory();

                return _sessionFactory;
            }
        }

        #endregion

        #region Static Method

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        #endregion
    }
}