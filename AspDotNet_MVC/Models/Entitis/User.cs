using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNet_MVC.Models.Entitis
{
    public class User
    {
        // Guid 
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime? Dob { get; set; }
        public string? Role { get; set; }
        public virtual ICollection<HoaDon>? HoaDons { get; set; }

        //public Guid IdGH { get; set; }
        public virtual GioHang? GioHangs { get; set; }
        // virtual: navigation dùng để điều hướng, load dữ liệu từ db lên
        // ICollection: là một Interface đại diện cho list, arraylist. Icollection dùng để thể hiện 1 user có nhiều hoá đơn đi kèm

    }
}
