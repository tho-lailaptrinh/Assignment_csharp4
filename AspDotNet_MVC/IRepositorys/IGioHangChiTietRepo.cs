using AspDotNet_MVC.Models.Entitis;

namespace AspDotNet_MVC.IRepositorys
{
    public interface IGioHangChiTietRepo
    {
        Task<IEnumerable<GioHangChiTiet>> GetGioHangCT();
        Task<GioHangChiTiet> CreateGioHangCT(GioHangChiTiet g);
        Task<GioHangChiTiet> UpdateGioHangCTr(Guid id, GioHangChiTiet g);
        Task<GioHangChiTiet> DeleteGioHangCT(Guid id);
    }
}
