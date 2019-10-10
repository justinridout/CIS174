using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CIS174_TestCoreApp.Models
{
    public class CreatePersonPlusViewModel
    {
        [Required]
        [StringLength(25)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]     
        [StringLength(25, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Range(1, 120)]
        public int Age { get; set; }

        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/1900", "12/31/2018",
        ErrorMessage = "Valid date of birth must be between 1/1/1900 and 12/31/2018")]
        [Display(Name = "Date Of Birth")]
        public string DateOfBirth { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress] 
        public string Email { get; set; }

        [Required]
        [Compare("ConfirmPassword", ErrorMessage = "Passwords Must Match")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords Must Match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public string Country { get; set; } 
        public IEnumerable<SelectListItem> Countries { get; set; }
            = new List<SelectListItem>
            {
                new SelectListItem{Value= "usa", Text = "USA"},
                new SelectListItem{Value= "mexico", Text = "Mexico"},
                new SelectListItem{Value = "canada", Text = "Canada"},
            };
    }
}
