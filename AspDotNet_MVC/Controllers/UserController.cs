using AspDotNet_MVC.IRepositorys;
using AspDotNet_MVC.Models.Data;
using AspDotNet_MVC.Models.Entitis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNet_MVC.Controllers
{
    public class UserController : Controller
    {
        private MyDbContext _context;
        private IUserRepo _userRepo;
        public UserController(IUserRepo userRepo, MyDbContext context)
        {
            _userRepo = userRepo;
            _context = context;
        }
        public async Task<IActionResult> Index(string name = "2134567fsdf")
        {
            ViewData["count"] = 0;   
            var data = await _userRepo.GetAllUser();
            var search =  data.Where(x => x.Name.Contains(name)).ToList();
            if (search.Count != 0)
            {
                ViewData["count"] = search.Count; // số lượng bản ghi đã đc tìm thấy
                return View(search);
            }
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] 
        public async Task<IActionResult> CreateUser(User user)
        {
            if (await _userRepo.UserExists(user.UserName))
            {
                ModelState.AddModelError("UserName", "Tên người dùng đã tồn tại!");
            }
            if (!ModelState.IsValid)
            {
                // Nếu có lỗi, trả về View "Create" với ModelState để hiển thị thông báo lỗi
                return View("Create", user);
            }
            await _userRepo.CreateUser(user);
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
                HttpContext.Session.SetString("IdUser", user.Id.ToString());
                return RedirectToAction("Welcome","User");
            }
            return Content("Đăng nhập thất bại");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("IdUser");
            return RedirectToAction("Login","User");
        }

        public IActionResult Welcome()
        {
            ViewBag.Message = HttpContext.Session.GetString("IdUser");
            return View();
        }
    }
}
