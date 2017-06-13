using DienThoaiShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1460650_.Areas.Admin.Models.Bus
{
    public class LoaiSanPham
    {
        public static IEnumerable<loaisp> DanhSach()
        {
            var db = new DienThoaiShopConnectionDB();
            return db.Query<loaisp>("select * from loaisp");
        }
        public static loaisp ChiTietSanPham(string id)
        {
            var db = new PetaPoco.Database("DienThoaiShopConnection");
            return db.SingleOrDefault<loaisp>("Select * from loaisp WHERE ID=@0", id);

        }
        public static void Them(loaisp lsp)
        {
            var db = new DienThoaiShopConnectionDB();
            db.Insert(lsp);
        }
        public static void Xoa(string id, loaisp lsp)
        {

            var db = new PetaPoco.Database("DienThoaiShopConnection");
            db.Delete<loaisp>("where ID=@0", id);
            //sp = ChiTietSanPham(id);
            //sp.BiXoa = 1;
            //db.Update("sanpham", "MaSanPham", sp);

        }
        public static void CapNhat(string id, loaisp lsp)
        {
            var db = new DienThoaiShopConnectionDB();
            db.Update<loaisp>("Set ID=@0,TenLoai=@1", lsp.ID, lsp.TenLoai, id);
            db.Update(id, lsp);
        }
    }
}