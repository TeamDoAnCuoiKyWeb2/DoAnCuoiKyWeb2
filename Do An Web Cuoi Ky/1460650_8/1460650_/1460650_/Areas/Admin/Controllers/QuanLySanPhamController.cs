using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using _1460650_.Models;
using DienThoaiShopConnection;
using _1460650_.Models.Bus;
using _1460650_.Areas.Admin.Models;
using System.IO;

namespace _1460650_.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class QuanLySanPhamController : Controller
    {
   


        // GET: Admin/QuanLySanPham
       public ActionResult Index()
        {
            var dsSanPham = SanPhamBus.DanhSach();
            return View(dsSanPham);
            
        }

        // GET: Admin/QuanLySanPham/Details/5
        public ActionResult Details(string id)
        {

            return View(QuanLyBus.ChiTietSanPham(id));
            //var dataContext = new PetaPoco.Database("DienThoaiShopConnection");
            //var employee = dataContext.SingleOrDefault<sanpham>("Select * from sanpham where MaSanPham=@0",id);
            //return View(employee);
        }

        // GET: Admin/QuanLySanPham/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Admin/QuanLySanPham/Create
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(sanpham sp)
        {
            // TODO: Add insert logic here
            if (HttpContext.Request.Files.Count > 0)
            {
                var hpf = HttpContext.Request.Files[0];
                if (hpf.ContentLength > 0)
                {
                    string filename = Guid.NewGuid().ToString();

                    string fullPathWithFileName = "/images/" + filename + ".jpg";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.hinhanh = fullPathWithFileName;
                }
            }
            QuanLyBus.Them(sp);
            return RedirectToAction("Index");
        }

        // GET: Admin/QuanLySanPham/Edit/5
        public ActionResult Edit(string id)
        {
            var dataContext = new PetaPoco.Database("DienThoaiShopConnection");
            var employee = dataContext.SingleOrDefault<sanpham>("Select * from sanpham where MaSanPham=@0",
                                                             id);
            return View(employee);
        }

        // POST: Admin/QuanLySanPham/Edit/5
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(sanpham sp)
        {
            try
            {
                if (HttpContext.Request.Files.Count > 0)
                {
                    var hpf = HttpContext.Request.Files[0];
                    if (hpf.ContentLength > 0)
                    {
                        string filename = Guid.NewGuid().ToString();

                        string fullPathWithFileName = "/images/" + filename + ".jpg";
                        hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                        sp.hinhanh = fullPathWithFileName;
                    }
                }
                // TODO: Add update logic here
                //QuanLyBus.CapNhat(id,sp);
                var dataContext = new PetaPoco.Database("DienThoaiShopConnection");
                dataContext.Update("sanpham", "MaSanPham", sp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/QuanLySanPham/Delete/5
        public ActionResult Delete(string id)
        {
            return View();

        }

        // POST: Admin/QuanLySanPham/Delete/5
        //@Html.ActionLink("Back to List", "Index")
        [HttpPost, ValidateInput(false)]
        public ActionResult Delete(string id, sanpham sp)
        {
            // TODO: Add delete logic here
            QuanLyBus.Xoa(id,sp);
            return RedirectToAction("Index");
        }

    }
}
