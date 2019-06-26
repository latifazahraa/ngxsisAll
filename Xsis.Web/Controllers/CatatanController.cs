using ngxsis.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ngxsis.Web.Controllers
{
    public class CatatanController : Controller
    {
        // GET: Catatan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult dataList()
        {
            return PartialView("_dataList");
        }

        public ActionResult Tampil()
        {
            return Json(CatatanRepo.GetAll(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add()
        {
            return View();
        }
    }
}