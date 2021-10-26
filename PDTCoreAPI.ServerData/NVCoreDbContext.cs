using Microsoft.EntityFrameworkCore;
using PDTCoreAPI.ServerData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PDTCoreAPI.ServerData
{
    public class NVCoreDbContext : DbContext
    {
        public NVCoreDbContext(DbContextOptions options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhanVien>().HasData(
                new NhanVien() { ID = Guid.NewGuid(), MaNhanVien = "901053", HoTenNhanVien = "PHAM DUC TRUONG", DiaChi = "178 KP Nui Dinh, Phuong Kim Dinh, TP Ba Ria", PhongBan = "IT" }
            );
        }

        public DbSet<NhanVien> NhanVien { get; set; }
    }
}
