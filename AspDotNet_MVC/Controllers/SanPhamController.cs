using Microsoft.AspNetCore.Mvc;
using AspDotNet_MVC.Repositorys;
using AspDotNet_MVC.Models.Entitis;
using AspDotNet_MVC.IRepositorys;
using AspDotNet_MVC.Models.Data;

namespace AspDotNet_MVC.Controllers
{
    public class SanPhamController : Controller
    {

        private readonly ISanPhamRepo _repo;
        private MyDbContext _context;
        public SanPhamController(ISanPhamRepo repo, MyDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        // GET: SanPhams
        public async Task<IActionResult> Index()
        {
            var data = await _repo.GetSanPhams();
            var tenDMSP =  _context.DanhMucSanPhams.ToDictionary(x => x.Id, x => x.TenDM);
            ViewBag.TenDMSP = tenDMSP;
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSP(SanPham sp, IFormFile imgFile)
        {
            // tạo ra một nơi lưu ảnh
            var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","img",imgFile.FileName);
            // copy ảnh và tải lên thư mục
            var stream = new FileStream(path, FileMode.Create); 
            // copy ảnh được chọn làm stream đó
            imgFile.CopyTo(stream);
            // cập nhật đường dẫn ảnh
            sp.ImgFile = imgFile.FileName;

            await _repo.CreateSP(sp);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(Guid id)
        {
            var getId = await _repo.GetById(id);
            return View(getId);
        }
        public async Task<IActionResult> UpdateSP(Guid id ,SanPham sp)
        {
            //var getId = await _repo.GetById(id);
            await _repo.UpdateSP(id,sp);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            //var getId = await _repo.GetById(id);
            await _repo.DeleteSP(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Detail(Guid id)
        {
            //var getId = await _repo.GetById(id);
            var getId = await _repo.GetById(id);
            return View(getId);
        }
        public async Task<IActionResult> Thuonghieu()
        {
            var data = await _repo.GetSanPhams();
            return View(data);
        }

        public IActionResult AddToCart(Guid id, int amount) // id ở đây là id sản phẩm và amount: số lượng sp
        {
            //check xem đã đăng nhập chưa
            var login = HttpContext.Session.GetString("IdUser");
            if (login == null)
            {
                return Content("Đã đăng nhập đâu anh bạn!");
            }
            else
            {
                // lấy tất cả sản phẩm có trong giỏ hàng user vừa đăng nhập
                var userCart = _context.GioHangChiTiets.Where(x => x.IdGH == Guid.Parse(login)).ToList();
                bool checkSelected = false;
                Guid idGHCT = Guid.Empty;
                foreach (var item in userCart)
                {
                    if(item.IdSP == id)
                    {
                        // nếu id sp trong giỏ hàng đã trùng với id được chọn
                        checkSelected = true;
                        idGHCT = item.Id; // lấy Id GHCT để tý nữa update
                        break;  
                    }
                }
                if (!checkSelected) // nếu sp chưa được chọn
                { 
                    // tạo mới 1 GHCT ứng với sản phẩm
                    GioHangChiTiet ghct = new GioHangChiTiet()
                    {
                        Id = Guid.NewGuid(),
                        IdSP = id,
                        IdGH = Guid.Parse(login),
                        Amount = amount
                    };
                    _context.GioHangChiTiets.Add(ghct);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else // nếu sản phẩm được chọn
                {
                    var updateGHCT = _context.GioHangChiTiets.Find(idGHCT);
                    updateGHCT.Amount = updateGHCT.Amount + amount;
                    _context.GioHangChiTiets.Update(updateGHCT);
                    _context.SaveChanges(true);
                    return RedirectToAction("Index");   
                            
                }
            }
        }
    }
}
