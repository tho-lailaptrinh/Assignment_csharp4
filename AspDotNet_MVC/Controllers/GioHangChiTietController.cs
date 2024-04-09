using AspDotNet_MVC.IRepositorys;
using AspDotNet_MVC.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNet_MVC.Controllers
{
    public class GioHangChiTietController : Controller
    {
        private IGioHangChiTietRepo _repo;
        private MyDbContext _context;

        public GioHangChiTietController(IGioHangChiTietRepo repo, MyDbContext context)
        {
            _repo = repo;
            _context = context;
        }
        public  IActionResult Index()
        {
            var data = _context.GioHangChiTiets.Where(x => x.IdGH == Guid.Parse(HttpContext.Session.GetString("IdUser"))).ToList();
            return View(data);
        }
        public IActionResult GHCT()
        {
            return View();
        }
        public IActionResult ThanhToan()
        {
            var LoginUser = HttpContext.Session.GetString("IdUser");
            if (LoginUser == null)
            {
                return Content("Đã đăng nhập đâu anh bạn");
            }
            var lstCart = _context.GioHangChiTiets.Where(x => x.IdGH == Guid.Parse(LoginUser)).ToList();
            foreach (var item in lstCart)
            {
                var product = _context.SanPhams.Find(item.Id);
                if (product != null)
                {
                    product.SoLuong -= item.Amount;
                    _context.SaveChanges();
                }
            }
            _context.GioHangChiTiets.RemoveRange(lstCart);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
