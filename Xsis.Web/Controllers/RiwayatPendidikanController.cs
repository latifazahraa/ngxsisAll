using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xsis.Model;
using Xsis.Repo;

namespace Xsis.Web.Controllers
{
    public class RiwayatPendidikanController : Controller
    {
        // GET: RiwayatPendidikan
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Tampil(int id)
        {
            return Json(RiwayatPendidikanRepo.GetAll(id), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Select()
        {
            try
            {
                return Json(RiwayatPendidikanRepo.GetSelect(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public ActionResult Tambah()
        {
            return PartialView("_Tambah");
        }

        public ActionResult Save(Riwayat_Pendidikan pendidikan)
        {
            pendidikan.created_by = Convert.ToInt64(Session["foo"]);
            if (RiwayatPendidikanRepo.Tmbhpendidikan(pendidikan))
            {
                return Json(new { Simpan = "Berhasil" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Simpan = "Gagal" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Hapus(int ID, Riwayat_Pendidikan pendidikan)
        {
            pendidikan.deleted_by = Convert.ToInt64(Session["foo"]);
            if (RiwayatPendidikanRepo.HapusPendidikan(ID,pendidikan)) //non static if ( barangRepo.Deletebarang(ID))
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
            return Json(RiwayatPendidikanRepo.GetByID(ID), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditSimpan(Riwayat_Pendidikan pendidikan)
        {
            pendidikan.modified_by = Convert.ToInt64(Session["foo"]);
            if (RiwayatPendidikanRepo.EditPendidikan(pendidikan))
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