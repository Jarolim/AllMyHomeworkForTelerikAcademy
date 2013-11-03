using _02.InformationalApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02.InformationalApplication.Controllers
{
    public class HomeController : Controller
    {
        RestaurantsDb db = new RestaurantsDb();
        
        public ActionResult Index()
        {
            var model = db.Restaurants.ToList();
            
            return View(model);
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