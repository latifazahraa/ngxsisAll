using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xsis.Model;
using Xsis.Repo;

namespace Xsis.Web.Controllers
{
    public class SertifikasiController : Controller
    {
        // GET: Sertifikasi
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tampil()
        {
            return Json(SertifikasiRepo.GetAll(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Tambah()
        {
            return PartialView("_Tambah");
        }

        public ActionResult Save(Sertifikasi sertif)
        {
            sertif.created_by = Convert.ToInt64(Session["foo"]);
            if (SertifikasiRepo.TmbhSertifikasi(sertif))
            {
                return Json(new { Simpan = "Berhasil" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Simpan = "Gagal" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Hapus(int ID, Sertifikasi sertif)
        {
            sertif.deleted_by = Convert.ToInt64(Session["foo"]);
            if (SertifikasiRepo.HapusSertifikasi(ID, sertif)) //non static if ( barangRepo.Deletebarang(ID))
            {
                return Json(new { Hapus = "Berhasil" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Hapus = "Gagal" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Edit(int ID)
        {
            return PartialView("_Edit");
        }

        public ActionResult AmbilData(int ID)
        {
            return Json(SertifikasiRepo.GetByID(ID), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditSimpan(Sertifikasi sertif)
        {
            sertif.modified_by = Convert.ToInt64(Session["foo"]);
            if (SertifikasiRepo.EditSertifikasi(sertif))
            {
                return Json(new { EditSimpan = "Berhasil" }, JsonRequestBehavior.AllowGet); //return json digunakan untuk memunculkan alert
            }
            else
            {
                return Json(new { EditSimpan = "Gagal" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}