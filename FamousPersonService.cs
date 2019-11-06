using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CIS174_TestCoreApp.Models;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Models.FamousPerson;

namespace CIS174_TestCoreApp
{
    public class FamousPersonService
    {
        readonly FamousPersonContext _context;
        public FamousPersonService(FamousPersonContext context)
        {
            _context = context;
        }

        public ICollection<FamousPersonSummaryViewModel> GetFamousPerson()
        {
            return _context.Persons
                .Where(r => !r.IsDeleted)
                .Select(x => new FamousPersonSummaryViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Accomplishments = x.Accomplishments.Count,
                })
                .ToList();
        }

        public FamousPersonDetailViewModel GetFamousPersonDetail(int id)
        {
            return _context.Persons
                .Where(x => x.Id == id)
                .Where(x => !x.IsDeleted)
                .Select(x => new FamousPersonDetailViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    State = x.State,
                    BirthDate = x.BirthDate,
                    City = x.City,
                    Accomplishments = x.Accomplishments
                    .Select(item => new FamousPersonDetailViewModel.Item
                    {
                        Name = item.Name,
                        Date = item.DateOfAccomplishment
                    })
                })
                .SingleOrDefault();
        }

        public UpdateFamousPersonCommand GetPersonForUpdate(int id)
        {
            return _context.Persons
                .Where(x => x.Id == id)
                .Where(x => !x.IsDeleted)
                .Select(x => new UpdateFamousPersonCommand
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    BirthDate = x.BirthDate,
                    City = x.City,
                    State = x.State,
                })
                .SingleOrDefault();
        }

        public int CreateFamousPerson (CreateFamousPersonCommand cmd)
        {
            var person = cmd.ToPerson();
            _context.Add(person);
            _context.SaveChanges();
            return person.Id;
        }

        public void UpdateFamousPerson(UpdateFamousPersonCommand cmd)
        {
            var person = _context.Persons.Find(cmd.Id);
            if (person == null) { throw new Exception("Unable to find that person"); }
            if (person.IsDeleted) { throw new Exception("Unable to update a deleted person"); }

            cmd.UpdatePerson(person);
            _context.SaveChanges();
        }

        public void DeleteFamousPerson(int Id)
        {
            var person = _context.Persons.Find(Id);
            if (person.IsDeleted) { throw new Exception("Unable to delete a deleted person"); }

            person.IsDeleted = true;
            _context.SaveChanges();
        }

        public bool DoesPersonExist(int id)
        {
            var person = _context.Persons.Find(id);

            if (person == null)
            {
                return false;
            }
            return !person.IsDeleted;
        }

        public void UpdatePerson(int id, UpdateFamousPersonCommand command)
        {
            var person = _context.Persons.Find(id);
            if (person == null)
            {
                throw new Exception("Unable to find person");
            }
            person.FirstName = command.FirstName;
            person.LastName = command.LastName;
            person.BirthDate = command.BirthDate;
            person.City = command.City;
            person.State = command.State;

            _context.SaveChanges();
        }

        public int CreateErrorLog(CreateErrorLogCommand cmd)
        {
            var error = cmd.ToLog();
            _context.Add(error);
            _context.SaveChanges();
            return error.Id;
        }

        public string GetPersonFirstName(int id)
        {
            return _context.Persons
                .Where(x => x.Id == id)
                .Select(x => x.FirstName)
                .SingleOrDefault();
                
        }
    }
}
