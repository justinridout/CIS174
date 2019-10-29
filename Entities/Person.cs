using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CIS174_TestCoreApp.Entities
{
    public class Person
    {
        [StringLength(25)]
        public string FirstName { get; set; }
        public int Id { get; set; }

        [StringLength(25)]
        public string LastName { get; set; }
        public string BirthDate { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        [StringLength(2)]
        public string State { get; set; }

        public bool IsDeleted { get; set; }
        public ICollection<Accomplishment> Accomplishments { get; set; }


    }
}
