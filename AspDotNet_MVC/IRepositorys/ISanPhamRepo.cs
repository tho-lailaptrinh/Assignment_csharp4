using AspDotNet_MVC.Models.Entitis;

namespace AspDotNet_MVC.IRepositorys
{
    public interface ISanPhamRepo
    {
        public Task<IEnumerable<SanPham>> GetSanPhams();
        public Task<SanPham> GetById(Guid id);
        public Task<SanPham> CreateSP(SanPham sp);
        public Task<SanPham> UpdateSP(Guid id,SanPham sp);
        public Task<SanPham> DeleteSP(Guid id);  
    }
}
