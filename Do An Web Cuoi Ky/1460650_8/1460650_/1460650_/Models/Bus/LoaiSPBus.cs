using DienThoaiShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1460650_.Models.Bus
{
    public class LoaiSPBus
    {
        public static IEnumerable<loaisp> DanhSach()
        {
            var db = new DienThoaiShopConnectionDB();
            return db.Query<loaisp>("select * from loaisp");

        }
        public static IEnumerable<sanpham> ChiTiet(int id)
        {
            var db = new DienThoaiShopConnectionDB();
            return db.Query<sanpham>("select * from sanpham where MaLoai = '" + id + "'");

        }
    }
}