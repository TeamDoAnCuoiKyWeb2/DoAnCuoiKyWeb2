using System.Web.Mvc;
using PagedList;
using PagedList.Mvc; 
namespace _1460650_.Controllers
{
    public class NhaSanXuatController : Controller
    {
        // GET: NhaSanXuat
        public ActionResult Index(int id)
        {
            //var dsSanPham = Areas.Admin.Models.NhaSXBus.DanhSach();
            //return View(dsSanPham);
            var ds = Models.Bus.NhaSXBus.ChiTiet(id);
            return View(ds);

        }

        // GET: NhaSanXuat/Details/5
        public ActionResult Details(string id)
        {
            return View(Areas.Admin.Models.NhaSXBus.ChiTietSanPham(id));
        }

        // GET: NhaSanXuat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhaSanXuat/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NhaSanXuat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NhaSanXuat/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NhaSanXuat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NhaSanXuat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
