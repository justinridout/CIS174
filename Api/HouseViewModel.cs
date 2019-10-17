using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class HouseViewModel
    {
        [Required]
        public int id { get; set; }

        [Required]
        [Range(1,20)]
        public int Bedrooms { get; set; }

        [Required]
        [Range(1, 3000)]
        public int SquareFeet { get; set; }

        [DataType(DataType.Date)]
        public string DateBuilt { get; set; }

        [Required]
        [StringLength(25)]
        public string Flooring { get; set; }


    }
}
