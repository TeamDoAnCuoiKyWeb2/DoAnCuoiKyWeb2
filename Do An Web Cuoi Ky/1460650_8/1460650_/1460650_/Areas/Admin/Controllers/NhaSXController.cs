using _1460650_.Areas.Admin.Models;
using DienThoaiShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1460650_.Areas.Admin.Controllers
{
    public class NhaSXController : Controller
    {
        // GET: Admin/NhaSX
        public ActionResult Index()
        {
            var dsnsx = NhaSXBus.DanhSach();
            return View(dsnsx);
        }

        // GET: Admin/NhaSX/Details/5
        public ActionResult Details(string id)
        {
            return View(NhaSXBus.ChiTietSanPham(id));
        }

        // GET: Admin/NhaSX/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhaSX/Create
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(nhasx nsx)
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
                        nsx.HinhAnh = fullPathWithFileName;
                    }
                }
                // TODO: Add insert logic here
                NhaSXBus.Them(nsx);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/NhaSX/Edit/5
        public ActionResult Edit(string id)
        {
            //return View();
            var dataContext = new PetaPoco.Database("DienThoaiShopConnection");
            var employee = dataContext.SingleOrDefault<sanpham>("Select * from nhasx where ID=@0",
                                                             id);
            return View(employee);
        }

        // POST: Admin/NhaSX/Edit/5
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(nhasx nsx)
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
                        nsx.HinhAnh = fullPathWithFileName;
                    }
                }
                // TODO: Add update logic here
                //NhaSXBus.CapNhat(id,nsx);
                // TODO: Add update logic here
                var dataContext = new PetaPoco.Database("DienThoaiShopConnection");
                dataContext.Update("nhasx", "ID", nsx);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/NhaSX/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/NhaSX/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, nhasx nsx)
        {
            try
            {
                // TODO: Add delete logic here
                NhaSXBus.Xoa(id,nsx);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
