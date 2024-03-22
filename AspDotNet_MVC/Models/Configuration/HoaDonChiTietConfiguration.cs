using AspDotNet_MVC.Models.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspDotNet_MVC.Models.Configuration
{
    public class HoaDonChiTietConfiguration : IEntityTypeConfiguration<HoaDonChiTiet>
    {
        public void Configure(EntityTypeBuilder<HoaDonChiTiet> builder)
        {
            builder.ToTable("HoaDonChiTiet");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.HoaDons).WithMany(x => x.HoaDonChiTiets).HasForeignKey(x => x.IdHD);
            builder.HasOne(x => x.SanPhams).WithMany(x => x.HoaDonChiTiets).HasForeignKey(x => x.IdSP);

            builder.HasOne(x => x.ThanhToans).WithMany(x => x.HoaDonChiTiets).HasForeignKey(x => x.IdTT);
            builder.HasOne(x => x.Shippings).WithMany(x => x.HoaDonChiTiets).HasForeignKey(x => x.IdDVVC);
        }
    }
}
