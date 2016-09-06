using System.Threading.Tasks;
using System.Web.Mvc;
using _2Version.Infastructure;
using _2Version.Models;

namespace _2Version.Controllers {
    public class AdminController : BaseController {
        private readonly UserRepository userRepository;

        public AdminController() {
            userRepository = UserRepository.Instance;
        }

        [HttpGet]
        public ActionResult List() {
            return View(userRepository.GetAll());
        }

        [HttpGet]
        [ActionName("Add")]
        public ActionResult Add() {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<ActionResult> Add(User user) {
            await Task.Factory.StartNew((() => { userRepository.Add(user); }));
            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeleteGet(int id) {
            return View(userRepository.Get(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id) {
            userRepository.Delete(id);
            return RedirectToAction("List");
        }

    }
}