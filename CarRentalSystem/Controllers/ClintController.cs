using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using CarRentalSystem.Models;
using CarRentalSystem.ViewModel;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using System.Text.RegularExpressions;

namespace CarRentalSystem.Controllers
{
    public class ClintController : Controller
    {
        private ApplicationDbContext db;
        private  CarClintViewModel Viewmodel;
        public SearchCarViewmodel searchmodel;
        public ClintController()
        {
            db = new ApplicationDbContext();
            Viewmodel = new CarClintViewModel();
            searchmodel = new SearchCarViewmodel();
        }
        // GET: Clint
        //from login to index-->clint object  
        [Route("Clint/Home/{id}")]
        public ActionResult Home(int id)
        {
            var categories = db.categories.ToList();
            var currentclint = db.clints.SingleOrDefault(c => c.id == id);
            Viewmodel.categories = categories;
            Viewmodel.clint = currentclint;

            searchmodel.categories = Viewmodel.categories;
            Viewmodel.viewmodel = searchmodel;
            return View(Viewmodel);   
        }
        [HttpPost]
        [Route("Clint/result")]
        public ActionResult result(SearchCarViewmodel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                if (viewmodel.car.color != null && !viewmodel.car.color.All(char.IsLetter))
                {
                    viewmodel.colorstate = 1;
                    viewmodel.messageerror = "the color field must be word without any number";
                    return Json(new { state = false, viewmodel = viewmodel});
                }else
                {
                  return Json(new { state = false, viewmodel = viewmodel });
                }
                
            }
            else
            {
                if (!viewmodel.car.color.All(char.IsLetter))
                {
                    viewmodel.colorstate = 1;
                    viewmodel.messageerror = "the color field must be word without any number";
                    return Json(new { state = false, viewmodel = viewmodel });
                }
                else
                {
                    return Json(new { state = true, viewmodel = viewmodel });
                }
            }
        }

        public ActionResult submitnotvalid(SearchCarViewmodel viewmodel)
        {
            viewmodel.categories = db.categories.ToList();
            return PartialView("searchform", viewmodel);
            //return Content("calleeeed");
        }
        public ActionResult ShowCars(SearchCarViewmodel viewmodel) 
        {
            var Carlist = db.cars.Include(c => c.categorytype).ToList().
                   Where(c => c.categorytypeid == viewmodel.car.categorytypeid && c.color == viewmodel.car.color && c.Model == viewmodel.car.Model && c.NumberOfChairs == viewmodel.car.NumberOfChairs && c.RentAmount <= viewmodel.car.RentAmount);
            if (Carlist.Count()>=1)
            {
                Viewmodel.cars = Carlist;
                Viewmodel.clint = db.clints.SingleOrDefault(c => c.id == viewmodel.id);
                Viewmodel.viewmodel = viewmodel;
                return PartialView(Viewmodel);
            }
            else 
            {
                return Content("<span class='cardon'texist'> this Car doesn't exists</span>");
            }
            
        }

        [HttpPost]
        //[Route("Clint//Information/")]
        public ActionResult ShowInformationAboutCar( int SSn,int id) 
        {
            var car = db.cars.Include(c => c.categorytype).SingleOrDefault(c => c.id == id);
            var clint = db.clints.SingleOrDefault(c => c.Ssn == SSn);
            Viewmodel.car = car;
            Viewmodel.clint = clint;
            return View(Viewmodel);
        }
        [HttpPost]
        [Route("Clint/Reservation")]
        public ActionResult Reservation(CarClintViewModel viewmodel)
        {
          if (viewmodel.car.To != null && viewmodel.car.From != null) 
             {
                if (viewmodel.car.To > viewmodel.car.From)
                {
                    try
                    {
                        //return Content("<h1>"+viewmodel.car.Name+"</h1>"+"hhhhhhhhh");
                        var car = db.cars.Include(c => c.categorytype).SingleOrDefault(c => c.id == viewmodel.car.id);
                        
                        car.From = viewmodel.car.From;
                        car.To = viewmodel.car.To;
                        car.clintid = viewmodel.clint.id;
                        var clint = db.clints.SingleOrDefault(c => c.id == viewmodel.clint.id);
                        db.SaveChanges();
                        TimeSpan Duration = new TimeSpan();
                        Duration = (TimeSpan)(viewmodel.car.To - viewmodel.car.From);
                        SendSms("+2"+clint.phone,"you are successfully rented this car :"+ car.Name+ " from :" + viewmodel.car.From + " :to:" + viewmodel.car.To + " " + " and the ending duration of rent is :" + Duration.Duration());
                        SendSms("+201276134569","The clint :"+clint.Name+"has id :"+clint.id+" have been rented this car :"+car.Name +" it's type " +car.categorytype.Name);
                        return Json(new { state = true, viewmodel = viewmodel, message = "the message it's on the way to you that confim you are rented thid car: "+car.Name });
                        //return Content();
                    }
                    catch (Exception e)
                    {
                        return Content(e.ToString());
                    }
                    
                }
                else 
                {
                    viewmodel.fromstate = 1;
                    viewmodel.tostate = 1;
                    viewmodel.messageerror = "the to date must be bigger than from date";
                    return Json(new { state = false, viewmodel = viewmodel });
                } 
            }else
            {
                if (viewmodel.car.From == null)
                {
                    viewmodel.fromstate = 1;
                    viewmodel.messageerror = "this field is required";
                    return Json(new { state = false, viewmodel = viewmodel });
                }
                else /*if (viewmodel.car.From == null) */
                {
                    viewmodel.tostate = 1;
                    viewmodel.messageerror = "this field is required";
                    return Json(new { state = false, viewmodel = viewmodel });
                }
                  
            }
           

        }
        public ActionResult SendSms(String Reciever, String Message)
        {
            //if (IsValidNum(Reciever) == true){
            // var accountSid= ConfigurationManager.AppSettings["TwilioAccountSid"];
            var accountSid = "ACc0bdc28f6febf87ff77eaa9e34f71996";
            var authToken = "368c61efd2522d221727bec00513c4b3";
            TwilioClient.Init(accountSid, authToken);
            //var to = new PhoneNumber(ConfigurationManager.AppSettings["MyPhoneNumber"]);
            var to = new PhoneNumber(Reciever);
            var from = new PhoneNumber("+18317775716");
            try
            {
                var message = MessageResource.Create(
                to: to,
                from: from,
                body: Message);
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            };


            return Content(Message);
            //}
            //else { return Content("there is an ERROR"); }
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        // GET: Clint
        public ActionResult Index()
        {
            var clints = db.clints.ToList();
            return View(clints);

        }
        public ActionResult deleteClint(int id)
        {
            var clint = db.clints.Single(m => m.id == id);
            db.clints.Remove(clint);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlockClint(int id)
        {
            var clint = db.clints.Single(m => m.id == id);
            return View();
        }

        bool IsValidNum(String Reciever)
        {
            return Regex.Match(Reciever, @"^(\+[0-9]{9})$").Success;
        }

    }

}
 
