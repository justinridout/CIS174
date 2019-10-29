using CIS174_TestCoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models.FamousPerson
{
    public class CreateFamousPersonCommand : EditFamousPersonBase
    {
        public IList<CreateAccomplishmentCommand> Accomplishments { get; set; } = new List<CreateAccomplishmentCommand>();

        public Person ToPerson()
        {
            return new Person
            {
                FirstName = FirstName,
                LastName = LastName,
                BirthDate = BirthDate,
                City = City,
                State = State,
                Accomplishments = Accomplishments?.Select(x => x.ToAccomplishment()).ToList()
            };
        }
    }
}
