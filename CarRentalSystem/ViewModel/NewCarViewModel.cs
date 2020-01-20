using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRentalSystem.Models;

namespace CarRentalSystem.ViewModel
{
    public class NewCarViewModel
    {
        public IEnumerable<Category> Category { get; set; }
        public Car Carr { get; set; }
        public HttpPostedFileBase Image { get; set; }

    }
}