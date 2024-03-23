using AspDotNet_MVC.IRepositorys;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNet_MVC.Controllers
{
    public class GioHangChiTietController : Controller
    {
        private IGioHangChiTietRepo _repo;

        public GioHangChiTietController(IGioHangChiTietRepo repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _repo.GetGioHangCT();
            return View();
        }
    }
}
