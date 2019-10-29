using CIS174_TestCoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class FamousPersonSummaryViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Accomplishments { get; set; }

        public static FamousPersonSummaryViewModel FromPerson(Person person)
        {
            return new FamousPersonSummaryViewModel
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Accomplishments = person.Accomplishments.Count,
            };
        }
    }
}
