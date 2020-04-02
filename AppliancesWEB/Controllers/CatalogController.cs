using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace AppliancesWEB.Controllers
{
    public class CatalogController : Controller
    {   AppliancesContext db = new AppliancesContext();
        // GET: Catalog
        public ActionResult Index()
        {
            var equip = db.Equipments.Where(eq=>eq.StateEquipment=="Новый").ToList();
            return View(equip);
        }
        public ActionResult Filter(FormCollection formCollection)
        {
            if (formCollection.GetValues("category") != null)
            {
                switch (formCollection.GetValue("category").AttemptedValue)
                {
                    case "Новый":
                        var eq1 = db.Equipments.Where(eq => eq.StateEquipment == "Новый").ToList();
                        return View("Index", eq1);
                    case "Уцененный":
                        var eq2 = db.Equipments.Where(eq => eq.StateEquipment == "Уценка").ToList();
                        return View("Index", eq2);
                    case "ВсяТехника":
                        var eq3 = db.Equipments.ToList();
                        return View("Index", eq3);
                    case "Отечественная":
                        var eq4 = db.Equipments.Where(eq => eq.Builder == "Россия").ToList();
                        return View("Index", eq4);
                }
                
            }
            else
            { 
                if(formCollection.GetValue("searchfromcost") !=null)
                { 
                    if(decimal.TryParse(formCollection.GetValue("cost").AttemptedValue , out decimal cost))
                    { 
                        var equip = db.Equipments.Where(eq => eq.Cost > cost)
                        .ToList();
                        return View("Index", equip);
                    }
                    else return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
            
            
        }
    }
}