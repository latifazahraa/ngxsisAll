using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xsis.Model;
using Xsis.Repo;

namespace Xsis.Web.Controllers
{
    public class AktivasiAkunTesOnlineController : Controller
    {
        // GET: AktivasiAkunTesOnline
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Aktifkan()
        {
            return PartialView("_Aktivasi");
        }

        public ActionResult TambahType()
        {
            return Json(AktivasiAkunTesOnlineRepo.GetAllType(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult TambahTes()
        {
            return Json(AktivasiAkunTesOnlineRepo.GetAllTes(), JsonRequestBehavior.AllowGet);
        }

    }
}