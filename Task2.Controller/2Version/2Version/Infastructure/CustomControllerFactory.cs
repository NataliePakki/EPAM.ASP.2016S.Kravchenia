using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using _2Version.Controllers;

namespace _2Version.Infastructure {
    public class CustomControllerFactory : IControllerFactory {
        public IController CreateController(RequestContext requestContext, string controllerName) {
            Type targetType;
            switch(controllerName) {
                case "Customer":
                case "User":
                    targetType = typeof(UserController);
                    break;
                case "Admin":
                    if (requestContext.HttpContext.Request.IsLocal) {
                        targetType = typeof (AdminController);
                        break;
                    } 
                    targetType = typeof(HomeController);
                    break;
                case "Home":
                    targetType = typeof (HomeController);
                    break;
                default:
                    requestContext.RouteData.Values["controller"] = "Base";
                    targetType = typeof(BaseController);
                    break;
            }
            return targetType == null ? null : (IController)DependencyResolver.Current.GetService(targetType);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName) {
           return controllerName == "Home" ? SessionStateBehavior.Disabled : SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller) {
            IDisposable disposable = controller as IDisposable;
            disposable?.Dispose();
        }
    }
}