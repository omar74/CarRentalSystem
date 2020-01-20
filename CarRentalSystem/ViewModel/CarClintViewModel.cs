using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRentalSystem.Models;
namespace CarRentalSystem.ViewModel
{
    public class CarClintViewModel
    {
        public Clint clint { set; get; }
        public IEnumerable<Car> cars { set; get; }
        public Car car { set; get; }
        public IEnumerable<Category> categories { set; get; }
        public int colorstate { set; get; }
        public int fromstate { set; get; }
        public string messageerror { set; get; }
        public int tostate { set; get; }
        public SearchCarViewmodel viewmodel { set; get; }
        //public IDictionary<string,bool> datatypeCheck { set; get; }
    }
}