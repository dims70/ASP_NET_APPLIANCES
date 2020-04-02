using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppliancesWEB.Controllers
{
    public class AccountController : Controller
    {
        AppliancesContext db = new AppliancesContext();
        public ActionResult Info()
        {
            var user = db.DataUsers.Where(data=>data.idUser==AuthUser.Id).ToList();
            if (user.Count!=0)
            {
                return View(user[0]);
            }
            return View();
            
        }
    }
}