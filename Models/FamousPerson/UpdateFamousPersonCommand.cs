using CIS174_TestCoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models.FamousPerson
{
    public class UpdateFamousPersonCommand : EditFamousPersonBase
    {
        public int Id { get; set; }

        public void UpdatePerson(Person person)
        {
            person.FirstName = FirstName;
            person.LastName = LastName;
            person.BirthDate = BirthDate;
            person.City = City;
            person.State = State;
        }
    }
}
