using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel;

namespace ArisiaProject.Dependency
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        #region Declarations

        private readonly IKernel _kernel;

        #endregion

        #region Constructor

        public WindsorControllerFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        #endregion

        #region Override Method

        public override void ReleaseController(IController controller)
        {
            _kernel.ReleaseComponent(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path {0} could not be found.", 
                    requestContext.HttpContext.Request.Path));
            }

            return (IController) _kernel.Resolve(controllerType);
        }

        #endregion
    }
}