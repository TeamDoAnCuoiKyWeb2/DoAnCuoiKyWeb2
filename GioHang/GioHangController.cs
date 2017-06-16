using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using _1460650_.Models.Bus;

namespace _1460650_.Controllers
{
    [Authorize]
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            return View(GioHangBus.DanhSach(User.Identity.GetUserId()));
        }
        [HttpPost]
        public ActionResult Them(int maSanPham, string maTaiKhoan, string gia, string soluong)
        {

            GioHangBus.Them(maSanPham, User.Identity.GetUserId(), gia, soluong);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult CapNhat(int maSanPham, string maTaiKhoan, string gia, string soluong, string tenSanPham)
        {

            GioHangBus.CapNhat(maSanPham, User.Identity.GetUserId(), gia, soluong);
            return RedirectToAction("Index");
        }
    }
}