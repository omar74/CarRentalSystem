using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRentalSystem.Models;

namespace CarRentalSystem.Controllers
{
    public class PaypalController : Controller
    {
        // GET: Paypal
        public ActionResult Index()
        {
            if (Session["cart"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            var ls = Session["cart"] as List<Car>;
            return View(ls);
        }

        public ActionResult get_data_paypal()
        {

            return View();
        }

    }
}