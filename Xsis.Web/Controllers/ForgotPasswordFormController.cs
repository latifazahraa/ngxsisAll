using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xsis.Model;
using Xsis.Repo;

namespace Xsis.Web.Controllers
{
    public class ForgotPasswordFormController : Controller
    {
        // GET: ForgotPasswordForm
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tampil()
        {
            return Json(ForgotPasswordFormRepo.GetAll(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AmbilData(int ID)
        {
            return Json(ForgotPasswordFormRepo.GetByID(ID), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditSimpan(AddrBook forgotpasswordform)
        {
            forgotpasswordform.modified_by = Convert.ToInt64(Session["foo"]);
            if (ForgotPasswordFormRepo.Editforgotpasswordform(forgotpasswordform))
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