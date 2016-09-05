using System.Web.Mvc;

namespace _2Version.Controllers {
    public class HomeController : BaseController {
        public ActionResult Index() {
            return View();
        }
    }
}