using AspDotNet_MVC.IRepositorys;
using AspDotNet_MVC.Models.Data;
using AspDotNet_MVC.Models.Entitis;
using Microsoft.EntityFrameworkCore;

namespace AspDotNet_MVC.Repositorys
{
    public class GioHangChiTietRepo : IGioHangChiTietRepo
    {
        private MyDbContext _context;
        public GioHangChiTietRepo(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GioHangChiTiet>> GetGioHangCT()
        {
            var result = await _context.GioHangChiTiets.ToListAsync();
            return result;
        }
        public Task<GioHangChiTiet> CreateGioHangCT(GioHangChiTiet g)
        {
            throw new NotImplementedException();
        }

        public Task<GioHangChiTiet> DeleteGioHangCT(Guid id)
        {
            throw new NotImplementedException();
        }


        public Task<GioHangChiTiet> UpdateGioHangCTr(Guid id, GioHangChiTiet g)
        {
            throw new NotImplementedException();
        }
    }
}
