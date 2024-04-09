using AspDotNet_MVC.IRepositorys;
using AspDotNet_MVC.Models.Data;
using AspDotNet_MVC.Models.Entitis;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace AspDotNet_MVC.Repositorys
{
    public class SanPhamRepo : ISanPhamRepo
    {
        private readonly MyDbContext _context;
        public SanPhamRepo(MyDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SanPham>> GetSanPhams()
        {
            var result = await  _context.SanPhams.ToListAsync();
            return result;
        }
        public async Task<SanPham> CreateSP(SanPham sp)
        {
            SanPham sanpham = new SanPham()
            {
                Id = Guid.NewGuid(),
                Ten = sp.Ten,
                Gia = sp.Gia,
                SoLuong = sp.SoLuong,
                ImgFile = sp.ImgFile,
                IdDMSP = sp.IdDMSP,
            };
            _context.SanPhams.Add(sanpham);
            await _context.SaveChangesAsync();
            return sanpham;
        }
        public async Task<SanPham> UpdateSP(Guid id, SanPham sp)
        {
            var updateSP = await _context.SanPhams.FirstOrDefaultAsync(x => x.Id == id);
            if (updateSP == null)
            {
                // Xử lý khi sản phẩm không tồn tại, ví dụ: throw exception hoặc trả về một kết quả tùy ý
                return null;
            }
            //var updateSP = await _context.SanPhams.FirstOrDefaultAsync(x=>x.Id == id);
            updateSP.Ten = sp.Ten;
            updateSP.Gia = sp.Gia;
            updateSP.SoLuong = sp.SoLuong;
            updateSP.IdDMSP = sp.IdDMSP; 
            _context.SanPhams.Update(sp);
            await _context.SaveChangesAsync();
            return updateSP;
        }
        public async Task<SanPham> DeleteSP(Guid id)
        {
            var deleteSP = await _context.SanPhams.FindAsync(id);
            _context.SanPhams.Remove(deleteSP);
            await _context.SaveChangesAsync();
            return deleteSP;
              
        }

        public async Task<SanPham> GetById(Guid id)
        {
            var getId = await _context.SanPhams.FindAsync(id);
            return getId;
        }
    }
}
