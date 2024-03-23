using AspDotNet_MVC.IRepositorys;
using AspDotNet_MVC.Models.Data;
using AspDotNet_MVC.Models.Entitis;
using Microsoft.EntityFrameworkCore;

namespace AspDotNet_MVC.Repositorys
{
    public class GioHangRepo : IGioHangRepo
    {
        private MyDbContext _context;
        public GioHangRepo(MyDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GioHang>> GetGioHang()
        {
            var result = await _context.GioHangs.ToListAsync();
            return result;
        }
        public Task<GioHang> CreateGioHang(GioHang g)
        {
            throw new NotImplementedException();
        }

        public Task<GioHang> DeleteGioHang(Guid id)
        {
            throw new NotImplementedException();
        }

     

        public Task<GioHang> UpdateGioHang(Guid id, GioHang g)
        {
            throw new NotImplementedException();
        }
    }
}
