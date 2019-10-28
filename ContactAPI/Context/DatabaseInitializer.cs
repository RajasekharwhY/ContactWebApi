using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ContactAPI.Models;

namespace ContactAPI.Context
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);           
          
            Contact contact1 = new Contact()
            {
                Name = new Name
                {
                    First = "Maria",
                    Middle = "Garcia",
                    Last = "Mary",
                    ContactId = 1
                },

                Address = new Address
                {
                    Street = "11345 Broad",
                    CityName = "Richmond",
                    StateName = "VA",
                    Zip = 23412,
                    ContactId = 1
                },
                Phone = new Phone
                {
                    Number = "234555",
                    Type = "Phone",
                    ContactId = 1
                },

                Email = "xyz@xyz"
            };

            Contact contact2 = new Contact()
            {
                Name = new Name
                {
                    First = "James",
                    Middle = "Simth",
                    Last = "David",
                    ContactId = 2
                },

                Address = new Address
                {
                    Street = "4532 Glenside",
                    CityName = "Norfolk",
                    StateName = "VA",
                    Zip = 23412,
                    ContactId = 2
                },
                Phone = new Phone
                {
                    Number = "234-555",
                    Type = "Cell",
                    ContactId = 2
                },

                Email = "xyz@xyz.com"
            };

            context.Contacts.Add(contact1);
            context.SaveChanges();
            context.Contacts.Add(contact2);
            context.SaveChanges();

        }
    }
}