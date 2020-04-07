using AppliancesWEB.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AppliancesWEB.Controllers
{
    public class AccountController : Controller
    {
        static DataUserForReg user = new DataUserForReg();
        AppliancesContext db = new AppliancesContext();
        public ActionResult Info()
        {   
            var users = db.DataUsers.Where(data => data.idUser == AuthUser.Id)
                .ToList();
            if (users.Count !=0)
            {
                user.DataUser = users[0];
                user.PayData = db.PayData.Where(data => 
                data.idUser == AuthUser.Id)
                .ToList()[0];
                return View(user);
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddPhoto(HttpPostedFileBase image)
        {   if(image.ContentType.Contains("image/"))
            { 
            image.SaveAs(Server.MapPath("~/Images/UserPhoto/" + image.FileName));
            db.DataUsers.Where(x => 
            x.idUser == AuthUser.Id)
            .ToList()[0]
            .imageUserPath = image.FileName;
            db.SaveChanges();
            user.DataUser.imageUserPath = image.FileName;
            }
            else ModelState.AddModelError("Error", "Выберите изображение!");
            
            return View("Info", user);
        }
    }
}