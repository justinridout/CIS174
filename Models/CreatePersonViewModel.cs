using System.ComponentModel.DataAnnotations;

namespace CIS174_TestCoreApp.Models
{
    public class CreatePersonViewModel
    {

        [Required]
        [StringLength(25)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(25)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Range(1, 120)]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Confirm Email")]
        [Compare("Email", ErrorMessage = "Emails Must Match Do Not Match")]
        public string ConfirmEmail { get; set; }

        [Url]
        [MinLength(7)]
        public string Website { get; set; }

        //[System.ComponentModel.ReadOnly(true)]
        [Editable(false)] /*Ive tried both of these attributes and none of them work. 
                            Everything Ive searched online tells me to use 
                            one of these two attributes and non of them work.
                            Can I get some guidance with this?*/
        public string School { get; set; }
    }
}
