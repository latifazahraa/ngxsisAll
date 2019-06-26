using ngxsis.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ngxsis.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult cekUser(string vUser) // nama vUser harus sama dengan yang ada di data ajax
        {
            return Json(AddrBookRepo.GetUname(vUser), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Attempt(int idUser)
        {
            return Json(AddrBookRepo.EditAddrBook(idUser), JsonRequestBehavior.AllowGet);
        }
        public ActionResult clearAttempt()
        {
            return Json(AddrBookRepo.clrAddrBook(), JsonRequestBehavior.AllowGet);
        }
    }
}