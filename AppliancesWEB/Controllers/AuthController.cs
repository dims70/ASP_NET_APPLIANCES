using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppliancesWEB.Controllers
{
    public class AuthController : Controller
    {
        AppliancesContext db = new AppliancesContext();
        public ActionResult Sign()
        {
            Referrer.UrlReferrer = Request.UrlReferrer+"";
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult In(FormCollection form)
        {
            var login =form.GetValue("login").AttemptedValue.ToString();
            var password = form.GetValue("pass").AttemptedValue.ToString();
            var authUser = db.AuthUsers.Where(authUsers=>
            authUsers.Login==login
                        && 
            authUsers.Password==password).ToList();
            if (authUser.Count()!=0)
            {
                AuthUser.Id = authUser[0].idUser;
                AuthUser.Login = authUser[0].Login;
                AuthUser.Email = authUser[0].Email;
                Session["Login"] = authUser[0].Login;
               return Redirect(Referrer.UrlReferrer);
            }
            Session["ErrorAuth"] = true;
            return View("Sign");
        }
        [HttpPost]
        public ActionResult Reg()
        {
            return View();
        }
        public ActionResult Out()
        {
            Session["Login"] = null;
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}