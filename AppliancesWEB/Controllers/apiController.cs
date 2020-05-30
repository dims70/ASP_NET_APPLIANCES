using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppliancesWEB.Controllers
{
    public class apiController : Controller
    {
        AppliancesContext db = new AppliancesContext();
        // GET: api
        public ActionResult Index()
        {
            return Content("api");
        }
        [HttpGet]
        public ActionResult Equipments(string token)
        {   if(token== "920446a876c8881baaaf58e1c0394086")
            { 
            return Json(db.Equipments.Select(x=>new { x.idEquipment,
                Categories = x.Categories.Name,
                x.StateEquipment,
                x.Description,
                x.Cost,
                x.Builder,
                x.imageEquipmentPath}).ToList(),JsonRequestBehavior.AllowGet);
            }
            return Json(new { error = "401" });  
        }
        [HttpGet]
        public ActionResult Orders(string token)
        {
            if (token == "920446a876c8881baaaf58e1c0394086")
            {
                return Json(db.Orders.Select(x => new {
                    x.idOrder,
                    x.idEquipment,
                   adress = x.AuthUsers.DataUsers.Region+" "+ x.AuthUsers.DataUsers.City+ " "+ x.AuthUsers.DataUsers.Adress,
                    x.Summary,
                    x.Statuses.Name,
                }).ToList(), JsonRequestBehavior.AllowGet);
            }
            return Json(new { error = "401" });
        }
    }
}