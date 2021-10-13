using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;//Namespace required for handling validations for UR dataa(MODEL)

namespace SampleMvcApp.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required(ErrorMessage ="Name is mandatory")]
        [MaxLength(12)]
        public string CustomterName { get; set; }

        [Required(ErrorMessage = "Email is mandatory")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string EmailAddress { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage ="Date must be set")]
        public DateTime BillDate { get; set; }

        [Range(20, 50,ErrorMessage ="Age should be b/w 20 to 50")]
        public int Age { get; set; }
    }
}