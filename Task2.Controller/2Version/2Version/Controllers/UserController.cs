using System.Threading.Tasks;
using System.Web.Mvc;
using _2Version.Infastructure;
using _2Version.Models;

namespace _2Version.Controllers {
    public class UserController : BaseController {
        private readonly UserRepository userRepository;

        public UserController() {
            userRepository = UserRepository.Instance;
        }

        [HttpPost]
        [ActionName("Add-User")]
        public async Task<ActionResult> Add(User user) {
            await userRepository.Add(user);
            return RedirectToAction("User-List");
        }

        [HttpGet]
        [ActionName("Add-User")]
        public ActionResult Add() {
            return View();
        }
        [HttpPost]
        [ActionName("User-List")]
        public ActionResult ListPost() {
            return Json(userRepository.GetAll(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [ActionName("User-List")]
        public ActionResult ListGet() {
            return View(userRepository.GetAll());
        }

    }
}