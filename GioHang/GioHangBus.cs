using DienThoaiShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1460650_.Models.Bus
{
    public class GioHangBus
    {
        public static void Them(int maSanPham, string maTaiKhoan, string gia, string soluong)
        {
            using (var db = new DienThoaiShopConnectionDB())
            {
                //var item = db.Query<GioHang2>("Select * from v_GioHang where MaTaiKhoan='" + maTaiKhoan + "'");
                GioHang2 Giohang = new GioHang2
                {

                    MaSanPham = maSanPham,
                    MaTaiKhoan = maTaiKhoan,
                    SoLuong = soluong,
                    Gia = gia,
                    
                    
                };
                db.Insert(Giohang);
            }
        }
        public static IEnumerable<v_GioHang> DanhSach(string maTaiKhoan)
        {
            using (var db = new DienThoaiShopConnectionDB())
            {
                return db.Query<v_GioHang>("Select * from v_GioHang where MaTaiKhoan = @0", maTaiKhoan);
            }
        }
        public static void CapNhat(int maSanPham, string maTaiKhoan, string gia, string soluong)
        {
            using (var db = new DienThoaiShopConnectionDB())
            {
                //db.Execute("UPDATE GioHang2 SET [SoLuong] = @0  WHERE id = @1" ,soLuong , id);
                GioHang2 Giohang = new GioHang2()
                {
                    MaSanPham = maSanPham,
                    MaTaiKhoan = maTaiKhoan,
                    SoLuong = soluong,
                    Gia = gia
                };
                var item = db.Query<GioHang2>("Select * from GioHang2  MaSanPham='"+maSanPham+"and MaTaiKhoan='"+maTaiKhoan+"'");
                db.Update(Giohang);
            }
        }
        }
    }
