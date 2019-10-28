using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactAPI.Context;
using ContactAPI.Models;

namespace ContactAPI.DbRepos
{
    public class ContactRepository : IContactRepository
    {
        private readonly  DatabaseContext contactContext;

        public  ContactRepository(DatabaseContext context)
        {
            contactContext = context;
        }

        public bool SaveChanges()
        {
            return (contactContext.SaveChanges()) > 0;
        }

        public void AddContact(Contact contact)
        {
            contactContext.Contacts.Add(contact);
        }

        public void DeleteContact(Contact contact)
        {
            contactContext.Contacts.Remove(contact);
        }

        public Contact[] GetContacts()
        {
            IQueryable<Contact> query  = contactContext.Contacts
                .Include("Name")
                .Include("Address")
                .Include("Phone");

            return query.ToArray();
        }

        public Contact GetContat(int Id)
        {
          IQueryable < Contact > query = contactContext.Contacts
                .Include("Name")
                .Include("Address")
                .Include("Phone");
            return query.Where(x => x.ContactId == Id).FirstOrDefault();
        }

        public void UpdateContact(int Id, Contact updateContact)
        {
            IQueryable<Contact> query = contactContext.Contacts
                .Include("Name")
                .Include("Address")
                .Include("Phone");
            var existingEntity = query.Where(x => x.ContactId == Id).FirstOrDefault();
            existingEntity = updateContact;
            contactContext.Entry(updateContact).State = System.Data.Entity.EntityState.Modified;

        }
    }
}