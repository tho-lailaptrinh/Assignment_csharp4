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
        [HttpPost] 
        
        public async Task<IActionResult> CreateUser(User u)
        {
            //var users = await _userRepo.GetAllUser();
            //var user = users.FirstOrDefault(x => x.UserName == u.UserName);
            if (await _userRepo.UserExists(u.UserName))
            {
                ModelState.AddModelError("UserName", "Tên người dùng đã tồn tại!");
            }
            if (!ModelState.IsValid)
            {
                // Nếu có lỗi, trả về View "Create" với ModelState để hiển thị thông báo lỗi
                return View("Create", u);
            }

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
        //Login
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
                HttpContext.Session.SetString("username",username);
                return RedirectToAction("Welcome","User");
            }
            return Content("Đăng nhập thất bại");
        }
        public IActionResult Welcome()
        {
            ViewBag.Message = "Đăng nhập thành công";
            ViewBag.Message2 = HttpContext.Session.GetString("username");
            return View();
        }
    }
}
