using System.EnterpriseServices;
using System.Web.Mvc;
using Task3.View.Infastructure;
using Task3.View.Models;

namespace Task3.View.Controllers {
    public class PersonController : Controller {
        private static Person person = new Person() {Id = 1, Name = "Melanie", IsWhite = true};
        public ActionResult Details() {
            return View("Person", person);
        }
 
        [ChildActionOnly]
        public ActionResult Footer() {
            return PartialView("_Footer");
        }
        [HttpPost]
        public bool JoinOtherSide() {
            if (person.IsWhite) {
                person.IsWhite = false;
                return true;
            } else return false;
        }
    }
}