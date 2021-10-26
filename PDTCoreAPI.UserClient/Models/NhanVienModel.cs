using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDTCoreAPI.UserClient.Models
{
    public class NhanVienModel
    {
        public Guid ID { get; set; }
        public string MaNhanVien { get; set; }
        public string HoTenNhanVien { get; set; }
        public string DiaChi { get; set; }
        public string PhongBan { get; set; }
    }
}