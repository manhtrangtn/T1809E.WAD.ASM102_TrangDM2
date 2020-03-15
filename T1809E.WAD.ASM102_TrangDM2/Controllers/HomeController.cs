using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T1809E.WAD.ASM102_TrangDM2.Data;
using T1809E.WAD.ASM102_TrangDM2.Models;

namespace T1809E.WAD.ASM102_TrangDM2.Controllers
{
    public class HomeController : Controller
    {
      ASM102Context db = new ASM102Context();
        public ActionResult Index()
        {
          var products = db.Products.ToList();
          var categories = db.Categories.ToList();
          var commonModel = new CommonModel()
          {
            Products = products,
            Categories = categories
          };
            return View(commonModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}