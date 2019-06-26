using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xsis.Repo;

namespace Xsis.Web.Controllers
{
    public class NewPasswordController : Controller
    {
        // GET: NewPassword
        public ActionResult Index(string shortURL)
        {
            if (ForgotPasswordRepo.VerificationLink(shortURL))
            {
                return PartialView("_Form"); //pas return true masuk ke tampilan form
            }
            else
            {
                return PartialView("_ExpForm"); //pas return false masuk ke tampilan "your token in expired"
            }
            
            
        }
    }
}