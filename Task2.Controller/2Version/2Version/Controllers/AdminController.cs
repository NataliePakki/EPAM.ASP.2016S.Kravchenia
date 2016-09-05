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
        [Local]
        [HttpGet]
        public ActionResult List() {
            return View(userRepository.GetAll());
        }
        [Local]
        [HttpGet]
        [ActionName("Add")]
        public ActionResult Add() {
            return View();
        }
        [Local]
        [HttpPost]
        [ActionName("Add")]
        public async Task<ActionResult> Add(User user) {
            await Task.Factory.StartNew((() => { userRepository.Add(user); }));
            return RedirectToAction("List");
        }

        [Local]
        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeleteGet(int id) {
            return View(userRepository.Get(id));
        }
        [Local]
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id) {
            userRepository.Delete(id);
            return RedirectToAction("List");
        }

    }
}