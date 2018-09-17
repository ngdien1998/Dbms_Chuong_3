using ConnectDatabaseDbms.Models.BusinessModels;
using ConnectDatabaseDbms.Models.DataModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ConnectDatabaseDbms.Controllers
{
    public class HomeController : Controller
    {
        private readonly SinhVienBusinessModel sinhVienModel;

        public HomeController()
        {
            sinhVienModel = new SinhVienBusinessModel();
        }

        public ActionResult Index(int? page)
        {
            List<SinhVien> sinhViens = null;
            const int pageRecordCount = 9;
            try
            {
                sinhViens = sinhVienModel.GetAll();
            }
            catch (Exception)
            {
                return new RedirectResult("/Login");
            }
            return View(sinhViens.ToPagedList(page ?? 1, pageRecordCount));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SinhVien model)
        {
            if (ModelState.IsValid)
            {
                sinhVienModel.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Creators()
        {
            return View();
        }

        public ActionResult Delete(string id)
        {
            List<SinhVien> sinhViens = sinhVienModel.GetAll();
            SinhVien sv = sinhViens.Find(item => item.MSSV == id);
            return View(sv);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            List<SinhVien> sinhViens = sinhVienModel.GetAll();
            SinhVien sv = sinhViens.Find(item => item.MSSV == id);
            sinhVienModel.Delete(sv);
            return RedirectToAction("Index");
        }
    }
}