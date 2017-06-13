using DienThoaiShopConnection;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1460650_.Models.Bus
{
    public class NhaSXBus
    {
        public static IEnumerable<nhasx> DanhSach()
        {
            var db = new DienThoaiShopConnectionDB();
            return db.Query<nhasx>("select * from nhasx");

        }
        //public static nhasx ChiTiet(int id)
        //{
        //    var db = new DienThoaiShopConnectionDB();
        //    return db.SingleOrDefault<nhasx>("select * from nhasx where ID=@0", id);
        //}
        public static IEnumerable<sanpham> ChiTiet(int id)
        {
            var db = new DienThoaiShopConnectionDB();
            return db.Query<sanpham>("select * from sanpham where NhaSX = '"+id+"'");

        }
    }

}