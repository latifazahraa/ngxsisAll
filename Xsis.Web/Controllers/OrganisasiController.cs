using Xsis.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xsis.Model;

namespace Xsis.Web.Controllers
{
    public class OrganisasiController : Controller
    {
        // GET: Organisasi
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tampil()
        {
            return Json(OrganisasiRepo.GetAll(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Select()
        {
            return Json(OrganisasiRepo.GetSelect(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            return PartialView("_Create");
        }
        public ActionResult Save(Organisasi organisasi)
        {
            organisasi.created_by = Convert.ToInt64(Session["foo"]);
            if (OrganisasiRepo.Createorganisasi(organisasi))
            {
                return Json(new { Simpan = "Berhasil" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Simpan = "Gagal" }, JsonRequestBehavior.AllowGet);
            }
            //return View();
        }


        public ActionResult Edit(int ID)
        {
            return PartialView("_Edit");
        }

        public ActionResult AmbilData(int ID)
        {
            return Json(OrganisasiRepo.GetByID(ID), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteConfirm(int ID)
        {
            return PartialView("_Delete");
        }

        public ActionResult Delete(int ID, Organisasi organisasimdl)
        {
            organisasimdl.deleted_by = Convert.ToInt64(Session["foo"]);
            if (OrganisasiRepo.Deleteorganisasi(ID, organisasimdl))
            {
                return Json(new { Hapus = "Berhasil" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Hapus = "Gagal" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult EditSimpan(Organisasi organisasi)
        {
            organisasi.modified_by = Convert.ToInt64(Session["foo"]);
            if (OrganisasiRepo.Editorganisasi(organisasi))
            {
                return Json(new { EditSimpan = "Berhasil" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { EditSimpan = "Gagal" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}