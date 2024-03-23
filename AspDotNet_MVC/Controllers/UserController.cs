using AspDotNet_MVC.IRepositorys;
using AspDotNet_MVC.Models.Entitis;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNet_MVC.Controllers
{
    public class UserController : Controller
    {
        private IUserRepo _userRepo;
        public UserController(IUserRepo userRepo)
        {
            _userRepo =userRepo;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _userRepo.GetAllUser();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        } 
        public async Task<IActionResult> CreateUser(User u)
        {
             await _userRepo.CreateUser(u);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(Guid id)
        {
            var user = await _userRepo.GetById(id);
            return View(user);
        }
        public async Task<IActionResult> UpdateUser(Guid id, User u)
        {
            await _userRepo.UpdateUser(id,u);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            await _userRepo.DeleteUser(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Detail(Guid id)
        {
            var user = await _userRepo.GetById(id);
            return View(user);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var users = await _userRepo.GetAllUser();
            var user = users.FirstOrDefault(p => p.UserName == username && p.Password == password);
            if (user != null)
            {
                return RedirectToAction("Index","Home");
            }
            return Content("Đăng nhập thất bại");
        }
    }
}
