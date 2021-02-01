using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class UserInfo
    {
        [DisplayName("First Name")]
        [Required(ErrorMessage ="First Name is required")]
        [MaxLength(30)]
        public string FirstName {get;set;}
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [MaxLength(30)]
        public string LastName { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(100)]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
        public string Email { get; set; }
        [DisplayName("Phone Number (optional)")]
        [MaxLength(30)]
        public string PhoneNumber { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^((?=.*[A-Z])(?=.*\d)(?=.*[a-z])|(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%&\/=?_.-])|(?=.*[A-Z])(?=.*[a-z])(?=.*[!@#$%&\/=?_.-])|(?=.*\d)(?=.*[a-z])(?=.*[!@#$%&\/=?_.-])).{7,15}$", ErrorMessage = "Needs at least 1 uppercase character, 1 lowercase character, 1 special character or number")]
        public string PassWord { get; set; }
        [DisplayName("Security Question")]
        [Required(ErrorMessage = "Please select your security question.")]
        public string SecurityQuestion { get; set; }
        [DisplayName("Security Answer")]
        [Required(ErrorMessage = "Please answer your security question.")]
        public string SecurityAnswer { get; set; }       
        public bool RecievePromotion { get; set; }
        public bool Enroll { get; set; }
        [DisplayName("Confirm Password")]
        [NotMapped]
        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(50, MinimumLength = 7)]
        [System.ComponentModel.DataAnnotations.Compare("PassWord", ErrorMessage = "Your passwords do not match.")]
        public string ConfirmPassword { get; set; }
        
    }

    
}