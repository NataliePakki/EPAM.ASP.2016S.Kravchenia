using System.Web.Mvc;

namespace _2Version.Controllers {
    public class BaseController : Controller {
        protected override void HandleUnknownAction(string actionName) {
            View("Error404").ExecuteResult(ControllerContext);
        }
    }
}