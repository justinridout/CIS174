﻿using CIS174_TestCoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models.FamousPerson
{
    public class FamousPersonDetailViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string BirthDate { get; set; }

        public string City { get; set; }

        public string State { get; set; }
        public IEnumerable<Item> Accomplishments { get; set; }
        public class Item
        {
            public string Name { get; set; }
            public string Date { get; set; }
        }
    }

   
}
