using AspDotNet_MVC.Models.Entitis;

namespace AspDotNet_MVC.IRepositorys
{
    public interface IDanhMucSPRepo
    {
        Task<List<DanhMucSanPham>> GetAll();
        Task<bool> CreateDM(DanhMucSanPham dmsp);
        Task<bool> UpdateDM(Guid id,DanhMucSanPham dmsp);
        Task<bool> DeleteDM(Guid id);

    }
}
