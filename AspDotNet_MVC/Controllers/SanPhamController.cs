using Microsoft.AspNetCore.Mvc;
using AspDotNet_MVC.Repositorys;
using AspDotNet_MVC.Models.Entitis;
using AspDotNet_MVC.IRepositorys;

namespace AspDotNet_MVC.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly ISanPhamRepo _repo;
        public SanPhamController(ISanPhamRepo repo)
        {
            _repo = repo;
        }

        // GET: SanPhams
        public async Task<IActionResult> Index()
        {
            var data = await _repo.GetSanPhams();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> CreateSP(SanPham sp)
        {
            var data = await _repo.CreateSP(sp);
            return RedirectToAction("Index");
        }
        public IActionResult Update()
        {
            return View();
        }
        public async Task<IActionResult> UpdateSP(Guid id ,SanPham sp)
        {
            //var getId = await _repo.GetById(id);
            await _repo.UpdateSP(id,sp);
            return RedirectToAction("Index");
        }
    }
}
