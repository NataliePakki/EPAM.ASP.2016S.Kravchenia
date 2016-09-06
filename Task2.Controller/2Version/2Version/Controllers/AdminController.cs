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
            await userRepository.Add(user);
            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteGet(int id) {
            return View(await userRepository.Get(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeletePost(int id) {
            await userRepository.Delete(id);
            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("Edit")]
        public async Task<ActionResult> EditGet(int id) {
            return View(await userRepository.Get(id));
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<ActionResult> EditPost(User user) {
            await userRepository.Edit(user);
            return RedirectToAction("List");
        }

    }
}