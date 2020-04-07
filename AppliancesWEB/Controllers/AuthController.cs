using AppliancesWEB.Models;
using System.Linq;
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
        public ActionResult Reg(DataUserForReg Model)
        {
            if (ModelState.IsValid)
            {
                db.AuthUsers.Add(Model.AuthUser);
                db.SaveChanges();
                var lastID = db.AuthUsers.ToList()[db.AuthUsers.Count()-1].idUser;
                Model.DataUser.idUser = lastID;
                Model.PayData.idUser = lastID;
                db.DataUsers.Add(Model.DataUser);
                db.PayData.Add(Model.PayData);
                db.SaveChanges();
                Model.AuthUser = null;
                Model.DataUser = null;
                Model.PayData = null;
                return RedirectToAction("Index","Home");
            }
                return View("Registration");

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
                if(Referrer.UrlReferrer!=null)
                { 
               return Redirect(Referrer.UrlReferrer);
                }
                return RedirectToAction("Home","Index");
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