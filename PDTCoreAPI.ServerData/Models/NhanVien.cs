using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PDTCoreAPI.ServerData.Models
{
    public class NhanVien
    {
        [Key]
        public Guid ID { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string MaNhanVien { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string HoTenNhanVien { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string DiaChi { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string PhongBan { get; set; }
    }
}
