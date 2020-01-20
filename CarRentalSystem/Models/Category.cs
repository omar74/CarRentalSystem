using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CarRentalSystem.Models
{
    public class Category
    {
        public int id { set; get; }
        public string Name { set; get; }
        [Display(Name = "Number Of Cars")]
        public int NumberOfCars { set; get; }
        public string Image { set; get; }
    }
}