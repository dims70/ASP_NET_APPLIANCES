using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppliancesWEB.Controllers
{
    public class HomeController : Controller
    {
        AppliancesContext db = new AppliancesContext();
        public ActionResult Index()
        {   
            ViewBag.Title = "Главная";
            var eqmain = db.Equipments.Take(6).ToList();
            return View(eqmain);
        }

    }
}