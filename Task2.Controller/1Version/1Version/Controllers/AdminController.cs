using System.Threading.Tasks;
using System.Web.Mvc;
using _1Version.Infastructure;
using _1Version.Models;

namespace _1Version.Controllers {
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
            await userRepository.Add(user);
            return RedirectToAction("List");
        }

        [Local]
        [HttpGet]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteGet(int id) {
            return View(await userRepository.Get(id));
        }

        [Local]
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeletePost(int id) {
            await userRepository.Delete(id);
            return RedirectToAction("List");
        }

        [Local]
        [HttpGet]
        [ActionName("Edit")]
        public async Task<ActionResult> EditGet(int id) {
            return View(await userRepository.Get(id));
        }

        [Local]
        [HttpPost]
        [ActionName("Edit")]
        public async Task<ActionResult> EditPost(User user) {
            await userRepository.Edit(user);
            return RedirectToAction("List");
        }

    }
}