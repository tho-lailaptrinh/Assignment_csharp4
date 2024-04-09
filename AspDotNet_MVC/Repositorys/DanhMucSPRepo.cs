using AspDotNet_MVC.IRepositorys;
using AspDotNet_MVC.Models.Data;
using AspDotNet_MVC.Models.Entitis;
using Microsoft.EntityFrameworkCore;

namespace AspDotNet_MVC.Repositorys
{
    public class DanhMucSPRepo : IDanhMucSPRepo
    {
        private MyDbContext _context;
        public DanhMucSPRepo()
        {
            _context = new MyDbContext();
        }
        public async Task<bool> CreateDM(DanhMucSanPham dmsp)
        {
            DanhMucSanPham DanhMuc = new DanhMucSanPham()
            {
                Id = Guid.NewGuid(),
                TenDM = dmsp.TenDM,
                MoTa = dmsp.MoTa,
            };
            _context.Add(DanhMuc);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDM(Guid id)
        {
            var getId = await _context.DanhMucSanPhams.FindAsync(id);
            if (getId != null)
            {
                _context.Remove(getId);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<List<DanhMucSanPham>> GetAll()
        {
            var data = await _context.DanhMucSanPhams.ToListAsync();
            return data;
        }

        public async Task<bool> UpdateDM(Guid id, DanhMucSanPham dmsp)
        {
            var getId = await _context.DanhMucSanPhams.FindAsync(id);
            if (getId == null)
            {
                return false;
            }
            getId.TenDM = dmsp.TenDM;
            getId.MoTa = dmsp.MoTa;
            _context.Update(getId);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
