using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models
{
    public class Clint
    {
   
        public int id { set; get; }
        [Required(ErrorMessage="name is required.")]
        public string Name { set; get; }
        [Required(ErrorMessage = "ssn is required.")]
        public int Ssn { set; get; }
        [Required(ErrorMessage = "age is required.")]
        public int Age { set; get; }
        [Required(ErrorMessage = "email is required.")]
        [EmailAddress]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage= " please enter valid email.")]
        public string Email { set; get; }
        [Required(ErrorMessage = "username is required.")]
        public string username { set; get; }
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8 )]
        [Required(ErrorMessage = "password is required.")]
        [DataType(DataType.Password)]
        public string password { set; get; }
        [Compare("password", ErrorMessage="please confirm your password.")]
        [DataType(DataType.Password)]
        public string confirmpassword { set; get; }
        [Required(ErrorMessage = "phone is required.")]

        public int phone { set; get; }
        public string PreferedCarType { set; get; }

        public Category categorytype { set; get; }
        
        [Display(Name = "Prefered Car type")]
        public int categorytypeid { set; get; }
        public bool blockstate { set; get; }

    }
} 