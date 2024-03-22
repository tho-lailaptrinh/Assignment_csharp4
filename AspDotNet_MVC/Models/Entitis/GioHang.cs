using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNet_MVC.Models.Entitis
{
    public class GioHang
    {
        public Guid Id { get; set; }
        public decimal? TongTien { get; set; }
        public Guid? IdUser { get; set; }
        public virtual User? Users { get; set; }
        public virtual ICollection<GioHangChiTiet>? GioHangChiTiets { get; set; }

    }
}
