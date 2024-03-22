namespace AspDotNet_MVC.Models.Entitis
{
    public class HoaDon
    {
        public Guid Id { get; set; }
        public decimal? TongTien { get; set; }
        public DateTime? NgayTao { get; set; } // ngày bán
        public int? TrangThai { get; set; } // trạng thái
        public Guid? IdUser { get; set; }
        public virtual User? Users { get; set; }
        public virtual ICollection<HoaDonChiTiet>? HoaDonChiTiets { get; set; }


    }
}
