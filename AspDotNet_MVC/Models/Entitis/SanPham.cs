namespace AspDotNet_MVC.Models.Entitis
{
    public class SanPham
    {
        public Guid Id { get; set; }
        public string? Ten { get; set; }
        public string? ImgFile { get; set; }
        public decimal? Gia { get; set; }
        public int? SoLuong { get; set; }
        public virtual ICollection<HoaDonChiTiet>? HoaDonChiTiets { get; set; }
        public virtual ICollection<GioHangChiTiet>? GioHangChiTiets { get; set; }
        public Guid? IdDMSP { get; set; }
        public virtual DanhMucSanPham? DanhMucSanPhams { get; set; }

        public virtual ICollection<DanhGiaSP>? DanhGiaSPs { get; set; }
    }
}
