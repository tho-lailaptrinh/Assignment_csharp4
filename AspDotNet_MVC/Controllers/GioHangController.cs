using AspDotNet_MVC.IRepositorys;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNet_MVC.Controllers
{
    public class GioHangController : Controller
    {
        private IGioHangRepo _repo;

        public GioHangController(IGioHangRepo repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var data =await _repo.GetGioHang();
            return View();
        }
    }
}
