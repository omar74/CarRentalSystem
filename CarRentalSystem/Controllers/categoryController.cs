using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRentalSystem.Models;
using CarRentalSystem.ViewModel;

namespace CarRentalSystem.Controllers
{
    public class categoryController : Controller
    {
        private ApplicationDbContext db;
        private  CarClintViewModel Viewmodel;
        public categoryController()
        {
            db = new ApplicationDbContext();
            Viewmodel = new CarClintViewModel();
        }
        // GET: category
        public ActionResult Index()
        {
            var categories = showcategory().ToList();
            return View(categories);
        }

        
        public IEnumerable<Category> showcategory()
        {
            var categories = db.categories.ToList();
            return categories;
        }
    }
}