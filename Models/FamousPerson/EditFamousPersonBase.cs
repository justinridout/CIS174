using System;
using System.ComponentModel.DataAnnotations;

namespace CIS174_TestCoreApp.Models.FamousPerson
{
    public class EditFamousPersonBase
    {

        [Required, StringLength(25)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(25)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, DataType(DataType.Date)]
        //[Range(typeof(DateTime), "1/1/1900", "12/31/2019",
        //ErrorMessage = "Value for {0} must be between {1} and {2}")]
        [Display(Name = "Date Of Birth")]
        public string BirthDate { get; set; }

        [Required, StringLength(30)]
        public string City { get; set; }

        [Required, StringLength(2)]
        public string State { get; set; }
    }
}