using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppliancesWEB.Controllers
{
    public class InfoController : Controller
    {
        AppliancesContext db = new AppliancesContext();
        public ActionResult InfoPage()
        {   
            return View();
        }
        [HttpPost]
        public ActionResult UserAnswer(FormCollection formCollection)
        {   
            db.Callback.Add(new Callback(AuthUser.Id,formCollection.GetValue("answer").AttemptedValue));
            db.SaveChanges();
            ViewBag.AnswerRequest = true;
            return View("InfoPage");
        }
    }
}