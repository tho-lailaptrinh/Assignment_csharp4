namespace AspDotNet_MVC.Models.Entitis
{
    public class Shipping
    {
        public Guid Id { get; set; }
        public string? Ten { get; set; }
        public string? DiaChi { get; set; }
        public string? Sdt { get; set; }
        public virtual ICollection<HoaDonChiTiet>? HoaDonChiTiets { get; set; }

    }
}
