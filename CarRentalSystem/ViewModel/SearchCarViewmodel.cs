using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRentalSystem.Models;
namespace CarRentalSystem.ViewModel
{
    public class SearchCarViewmodel
    {
        public IEnumerable<Car> cars { set; get; }
        public Car car { set; get; }
        public IEnumerable<Category> categories { set; get; }
        public int colorstate { set; get; }
        public string messageerror { set; get; }
        public int id { set; get; }
    }
}