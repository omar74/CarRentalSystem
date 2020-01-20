using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CarRentalSystem.ViewModel;
using CarRentalSystem.Models;

using System.Drawing;
using System.Web.Helpers;
using System.Net.Mail;
using Org.BouncyCastle.Crypto.Tls;
using CarCarRentalSystemRental.Models;

namespace CarRentalSystem.Controllers
{
    public class CarsController : Controller
    {
        private ApplicationDbContext _context;
        private ApplicationDbContext _context2;
      

        public CarsController()
        {
            _context = new ApplicationDbContext();
            _context2 = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            _context2.Dispose();
        }

        public ActionResult Add()
        {
            var category = _context.categories.ToList();
            NewCarViewModel viewmodel = new NewCarViewModel()
            {
                Category = category
            };
           
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Add(NewCarViewModel ViewModel,HttpPostedFileBase File)
        {
          /*  if (!ModelState.IsValid)
            {
                var category = _context.categories.ToList();
                ViewModel.Category = category;
                return View("Add", ViewModel);
            }*/
            UploadFile(File);
            string fileName = Path.GetFileName(File.FileName);
            ViewModel.Carr.ImagePath = "~/Upload/" + fileName;
            _context.cars.Add(ViewModel.Carr);
            _context.SaveChanges();
            var clints = _context.clints.ToList();
           
            string logopath = System.Web.HttpContext.Current.Server.MapPath(ViewModel.Carr.ImagePath);
            foreach (var cli in clints)
            {
                if (cli.categorytypeid == ViewModel.Carr.categorytypeid)
                {
                    sendMail(cli.Email,
               "<p>look we added a new car from the same type you like :) <pr> </p> <p> car Name is :" + ViewModel.Carr.Name + "</pr>" + "<pr> <p> Model :" + ViewModel.Carr.Model + "</p>" + "<p> Sate:" + "<p>",ViewModel.Carr.ImagePath);
                }
            }
            return RedirectToAction("Index");
            
           
        }
        private void sendMail(string x,string body,string Path)
        {
            
            
            MailMessage Mail = new MailMessage();
            Mail.To.Add(x);
            Mail.From = new MailAddress("tito68932@gmail.com");
            Mail.Subject = "New Car Type ";
            Mail.Body = body;
            Mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("tito68932@gmail.com", "248mus1997");
            smtp.Port = 587;
            smtp.EnableSsl = true;
         /*   string path = Server.MapPath(Path);
            LinkedResource logo = new LinkedResource(path);
            logo.ContentId = "carlogo";
            ContentType mimeType = new System.Net.Mime.ContentType("text/html");
            AlternateView av1 = AlternateView.CreateAlternateViewFromString(body,mimeType);
            av1.LinkedResources.Add(logo);
            Mail.AlternateViews.Add(av1);*/
            smtp.Send(Mail);
        }
        public ActionResult Edit(int id)
        {
            var car = _context.cars.Single(c => c.id == id);
            var category = _context.categories.ToList();
            NewCarViewModel viewModel = new NewCarViewModel
            {
                Category = category,
                Carr = car
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(NewCarViewModel car)
        {
            var carDB = _context.cars.Single(c => c.id == car.Carr.id);
            carDB.Name = car.Carr.Name;
            carDB.color = car.Carr.color;
            carDB.Model = car.Carr.Model;
            carDB.NumberOfChairs = car.Carr.NumberOfChairs;
            carDB.RentAmount = car.Carr.RentAmount;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
      
        public ActionResult Delete(int id)
        {
            var car = _context.cars.Single(m => m.id == id);
            _context.cars.Remove(car);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            var cars = _context.cars.Include(c => c.categorytype).ToList();
         //   REPORT (cars);
            return View(cars);
     
        }
        public ActionResult Details(int id)
        {
            var Car = _context.cars.Include(c => c.categorytype).SingleOrDefault(c => c.id == id);
            if (Car == null)
                return HttpNotFound();

            return View(Car);
        }
         public void UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Upload/"), _FileName);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
               
            }
        }
        public ActionResult REPORT (Car car )
        {
            var cars = _context.cars.ToList();
            CarsReport CarReport = new CarsReport();
            byte[] abytes = CarReport.prepareReport(cars);  
            return File(abytes,"application/pdf");
        }
       

    }
}