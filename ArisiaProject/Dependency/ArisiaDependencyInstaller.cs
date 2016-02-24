using System.Configuration;
using ArisiaProject.Helper;
using ArisiaProject.UnitOfWork;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NHibernate;

namespace ArisiaProject.Dependency
{
    public class ArisiaDependencyInstaller : IWindsorInstaller
    {
        #region IWindsorInstaller Method

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.ComponentRegistered += Kernel_Com
        }

        #endregion

        #region Private Method

        void Kernel_ComponentRegistered(string key, IHandler handler)
        {
            if (UnitOfWorkHelper.IsRepositoryClass(handler.ComponentModel.Implementation))
            {
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(NhUnitOfWorkInterceptor)));
            }

            foreach (var methodInfo in handler.ComponentModel.Implementation.GetMethods())
            {
                if (UnitOfWorkHelper.HasUnitOfWorkAttribute(methodInfo))
                {
                    handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(NhUnitOfWorkInterceptor)));
                }
            }
        }

        private static ISessionFactory CreateNhSessionFactory()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[""]
        }

        #endregion
    }
}