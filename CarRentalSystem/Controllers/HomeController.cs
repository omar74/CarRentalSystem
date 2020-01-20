using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRentalSystem.Models;

namespace CarRentalSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Car p)
        {
            if (Session["cart"] != null)
            {
                var ls = Session["cart"] as List<Car>;
                ls.Add(p);
            }
            else
            {
                Session["cart"] = new List<Car>() { p };   
            }
            ModelState.Clear();
            RedirectToAction("Index", "Home");
            return View();
        }
    }
}