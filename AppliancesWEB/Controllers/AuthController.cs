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
        [HttpPost]
        public ActionResult Reg(Models.DataUserForReg dataUserSummary)
        {
            if (ModelState.IsValid)
            {
                db.AuthUsers.Add(dataUserSummary.AuthUser);
                db.SaveChanges();
                var lastID = db.AuthUsers.ToList()[db.AuthUsers.Count()-1].idUser;
                dataUserSummary.DataUser.idUser = lastID;
                dataUserSummary.PayData.idUser = lastID;
                db.DataUsers.Add(dataUserSummary.DataUser);
                db.PayData.Add(dataUserSummary.PayData);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
                return View("Registration", dataUserSummary);

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
        
        public ActionResult Out()
        {
            Session["Login"] = null;
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}