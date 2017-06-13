using DienThoaiShopConnection;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1460650_.Models.Bus
{
    public class SanPhamBus
    {
        public static IEnumerable<sanpham> DanhSach()
        {
            var db = new DienThoaiShopConnectionDB();
            return db.Query<sanpham>("select * from sanpham");

        }
        public static Page<sanpham> DanhSach(int pageNumber, int itemPerPage)
        {
            var db = new DienThoaiShopConnectionDB();
            return db.Page<sanpham>(pageNumber,itemPerPage, "select * from sanpham");

        }
        public static sanpham ChiTiet(int id )
        {
            var db = new DienThoaiShopConnectionDB();
            return db.SingleOrDefault<sanpham>("select * from sanpham where MaSanPham=@0", id);
        }

        //public static void Them(sanpham sp)
        //{
        //    var db = new DienThoaiShopConnectionDB();
        //    db.Insert(sp);
        //}
    }
}