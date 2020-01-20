using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRentalSystem.Models;
namespace CarRentalSystem.ViewModel
{
    public class RigestrationViewModel
    {
        public IEnumerable<Category> categories { set; get; }
        public Clint clint { get; set; }

    }
}