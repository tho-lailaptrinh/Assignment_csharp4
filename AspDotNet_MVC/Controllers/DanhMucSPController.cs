using AspDotNet_MVC.IRepositorys;
using AspDotNet_MVC.Models.Entitis;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNet_MVC.Controllers
{
    public class DanhMucSPController : Controller
    {
        private IDanhMucSPRepo _repo;
        public DanhMucSPController(IDanhMucSPRepo repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _repo.GetAll();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DanhMucSanPham dmsp)
        {
            await _repo.CreateDM(dmsp);
            return RedirectToAction("Index");
        }

    }
}
