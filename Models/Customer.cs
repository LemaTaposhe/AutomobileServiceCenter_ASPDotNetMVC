using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcProject_Lema.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [DisplayName("Customer Name")]
        [Required(ErrorMessage = "Name is Required!")]
        [StringLength(30, ErrorMessage = "Name Must Be in 20 Character")]

        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100, ErrorMessage = "Email must be less than 100 characters")]
        public string Email {  get; set; }

        public string CarNumber { get; set; }

        [Required(ErrorMessage = "Enter Cellphone No.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be 11 digits")]
        public string PhoneNumber { get; set; }
    }
}