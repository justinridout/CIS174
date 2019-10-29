using CIS174_TestCoreApp.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace CIS174_TestCoreApp.Models.FamousPerson
{
    public class CreateAccomplishmentCommand
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        //[Range(typeof(DateTime), "1/1/1900", "12/31/2019",
        //ErrorMessage = "Value for {0} must be between {1} and {2}")]
        [Display(Name = "Date Of Accomplishment")]
        public string DateOfAccomplishment { get; set; }

        public Accomplishment ToAccomplishment()
        {
            return new Accomplishment
            {
                Name = Name,
                DateOfAccomplishment = DateOfAccomplishment,
            };
        }
    }
}
