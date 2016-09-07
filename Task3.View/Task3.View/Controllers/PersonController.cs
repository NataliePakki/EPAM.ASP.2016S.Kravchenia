using System.EnterpriseServices;
using System.Web.Mvc;
using Task3.View.Infastructure;
using Task3.View.Models;

namespace Task3.View.Controllers {
    public class PersonController : Controller {
//        private PersonRepository repository = PersonRepository.Instance;
        // GET: Person
        private static Person person = new Person() {Id = 1, Name = "Jack", IsWhite = false};
        public ActionResult Details() {
            return View("Person", person);
        }
 
        [ChildActionOnly]
        public ActionResult Footer() {
            return PartialView("_Footer");
        }
        [HttpPost]
        public bool JoinOtherSide() {
            person.IsWhite = !person.IsWhite;
            return !person.IsWhite;
        }
    }
}