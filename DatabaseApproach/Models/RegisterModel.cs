using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DatabaseApproach.Models
{
    public class RegisterModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage ="UserName Cannot Be Empty")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Cannot Be Empty")]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage = "Mismatch of Password and Confirm Password")]
        public string ConfirmPassword { get; set; }
        [Range(18,45,ErrorMessage ="18-45 can Apply for Job")]
        public int Age { get; set; }
        [DataType(DataType.EmailAddress,ErrorMessage ="Email ID Format is not Correct")]
        public string EmailId { get; set; }
        [StringLength(10,ErrorMessage ="Not Allowed more then 10 character")]
        public string Address { get; set; }

    }
}