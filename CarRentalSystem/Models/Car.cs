using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models
{
    public class Car
    {
        public int id { set; get; }
        
        [Display(Name = "Car Name")]
        public string Name { set; get; }
        [Required(ErrorMessage = "you have to Enter Car Model")]
        [Display(Name = "Car Model")]
        public string Model { set; get; }
        [Required(ErrorMessage = "you have to Enter Car Color")]
        [Display(Name = "Color")]
        public string color { set; get; }
        public string ImagePath { set; get; }
        [Required]
        [Display(Name = "Number Of chair")]
        public int NumberOfChairs { set; get; }
        [Required]
        [Display(Name="Rent amount" )]
        public float RentAmount { set; get; }
        public bool State { set; get; }
        public Category categorytype { set; get; }
        [Required]
        [Display(Name = "Category")]
        public int categorytypeid { set; get; }
        public Clint clint { set; get; }
        public int? clintid { set; get; }
        public DateTime? From { set; get; }
        public DateTime? To { set; get; }
    }
}