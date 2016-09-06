using System.Web.Mvc;

namespace _1Version.Controllers {
    public class BaseController : Controller {
        protected override void HandleUnknownAction(string actionName) {
            View("Error404").ExecuteResult(ControllerContext);
        }
    }
}