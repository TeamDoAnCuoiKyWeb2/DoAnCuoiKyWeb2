using _1460650_.Areas.Admin.Models.Bus;
using DienThoaiShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1460650_.Areas.Admin.Controllers
{
    public class LoaiSPController : Controller
    {
        // GET: Admin/LoaiSP
        public ActionResult Index()
        {

            var dslsp = LoaiSanPham.DanhSach();
            return View(dslsp);
        }

        // GET: Admin/LoaiSP/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/LoaiSP/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSP/Create
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(loaisp lsp)
        {
            try
            {
                // TODO: Add insert logic here
                LoaiSanPham.Them(lsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/LoaiSP/Edit/5
        public ActionResult Edit(string id)
        {
            //return View();
            var dataContext = new PetaPoco.Database("DienThoaiShopConnection");
            var employee = dataContext.SingleOrDefault<sanpham>("Select * from loaisp where ID=@0",
                                                             id);
            return View(employee);
        }

        // POST: Admin/LoaiSP/Edit/5
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(loaisp lsp)
        {
            try
            {
                // TODO: Add update logic here
                //LoaiSanPham.CapNhat(id,lsp);
                var dataContext = new PetaPoco.Database("DienThoaiShopConnection");
                dataContext.Update("loaisp", "ID", lsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/LoaiSP/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/LoaiSP/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, loaisp lsp)
        {
            try
            {
                // TODO: Add delete logic here
                LoaiSanPham.Xoa(id, lsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
