using AspDotNet_MVC.Models.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspDotNet_MVC.Models.Configuration
{
    public class GioHangChiTietConfiguration : IEntityTypeConfiguration<GioHangChiTiet>
    {
        public void Configure(EntityTypeBuilder<GioHangChiTiet> builder)
        {
            builder.ToTable("GioHangChiTiet");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.SanPhams).WithMany(x => x.GioHangChiTiets).HasForeignKey(x => x.IdSP);
            builder.HasOne(x => x.GioHangs).WithMany(x => x.GioHangChiTiets).HasForeignKey(x => x.IdGH);
        }
    }
}
