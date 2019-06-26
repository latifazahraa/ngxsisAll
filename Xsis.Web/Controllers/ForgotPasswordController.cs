using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xsis.Repo;

namespace Xsis.Web.Controllers
{
    public class ForgotPasswordController : Controller
    {
        // GET: ForgotPassword
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult EmailValid(string email)
        {
           return Json(ForgotPasswordRepo.FindEmail(email), JsonRequestBehavior.AllowGet);
        }

        public ActionResult TrySendEmail(string email)
        {

                return Json(ForgotPasswordRepo.SendEmail(email), JsonRequestBehavior.AllowGet);
        }
    }
}