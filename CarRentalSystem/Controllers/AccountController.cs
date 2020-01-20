using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRentalSystem.Models;
using CarRentalSystem.ViewModel;
namespace CarRentalSystem.Controllers
{
    public class accountController : Controller
    {
        private ApplicationDbContext db;
        private  CarClintViewModel Viewmodel;
        public SearchCarViewmodel searchmodel;
        public RigestrationViewModel rigester;
        public NewCarViewModel Viewmodel2;
        public accountController()
        {
            db = new ApplicationDbContext();
            Viewmodel = new CarClintViewModel();
            searchmodel = new SearchCarViewmodel();
            rigester = new RigestrationViewModel();
            Viewmodel2 = new NewCarViewModel();
        }
        // GET: account
       /* public ActionResult Index()
        {
            
                return View(db.clints.ToList());
        }*/

        public ActionResult register()
        {
            RigestrationViewModel rigester = new RigestrationViewModel
            {
                categories = db.categories.ToList()
            };
             
            return View(rigester);
        }

        [HttpPost]
        public ActionResult register(RigestrationViewModel account)
        {

            if (ModelState.IsValid)
            {

                db.clints.Add(account.clint);
                db.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = account.clint.Name+ " successfully register :) ";
            }
            else 
            {
                View(account);
            }
            account.categories = db.categories.ToList();

            return View(account);
        }

        //login 

        public ActionResult login()
        {
            return View();

        }
        [HttpPost]

        public ActionResult login(Clint user)
        {
            
               // var usr = db.clint.Where(u => u.Name == user.Name && u.password == user.password).FirstOrDefault();
                var usr = db.clints.Where(u => u.username == user.username && u.password == user.password).FirstOrDefault();

                if (usr != null)
                {
                    if(user.username == "kahraba")
                    {
                        Session["id"] = usr.id;
                        Session["username"] = "Kahraba";
                        return RedirectToAction("loggedin");
                    }else
                    {
                        Session["id"] = usr.id;
                        Session["username"] = usr.username;
                        return RedirectToAction("loggedin");
                    }
                }

            

            return View();
        }

       public ActionResult loggedin ()
        {
            if (Session["id"]!= null)
            {
                if(Session["username"] == "Kahraba")
                {
                    List<Car> cars = new List<Car>();
                    return View("~/Views/Cars/Index.cshtml", cars);
                }
               else
                {

                    int id = Convert.ToInt32(Session["id"]);
                    var categories = db.categories.ToList();
                    var currentclint = db.clints.SingleOrDefault(c => c.id == id);
                    Viewmodel.categories = categories;
                    Viewmodel.clint = currentclint;
                    searchmodel.categories = Viewmodel.categories;
                    searchmodel.id = id;
                    Viewmodel.viewmodel = searchmodel;

                    return View("~/Views/Clint/Home.cshtml", Viewmodel);
                }
            }

            else
            {
                return RedirectToAction("login");
            }
        }

        public ActionResult logout()
        {
            Session["clint"] = null;
            return RedirectToAction("Index", "category");
        }
     }
}








