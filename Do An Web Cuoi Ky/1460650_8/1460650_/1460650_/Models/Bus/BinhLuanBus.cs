using DienThoaiShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1460650_.Models.Bus
{
    public class BinhLuanBus
    {
        public static void Them(int MaSanPham, string MaTaiKhoan, string TenTaiKhoan, string NoiDung)
        { 
            using (var db = new DienThoaiShopConnectionDB())
            {
                BinhLuan binhluan = new BinhLuan();
                binhluan.MaSanPham = MaSanPham;
                binhluan.MaTaiKhoan = MaTaiKhoan;
                binhluan.NoiDung = NoiDung;
                db.Execute("INSERT INTO [webbandienthoai].[dbo].[BinhLuan]([MaSanPham],[MaTaiKhoan],[TenTaiKhoan],[NoiDung])VALUES(@0,@1,@2,@3)",MaSanPham,MaTaiKhoan,TenTaiKhoan,NoiDung);
            }
        }
        public static IEnumerable<BinhLuan>DanhSach(int MaSanPham)
        {
            using (var db = new DienThoaiShopConnectionDB())
            {
                return db.Query<BinhLuan>("select * from BinhLuan where MaSanPham=@0", MaSanPham);
            }
        }
    }
}