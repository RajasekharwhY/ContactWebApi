using ContactAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAPI.DbRepos
{
    public interface IContactRepository
    {
        bool SaveChanges();
        Contact[] GetContacts();
        Contact GetContat(int Id);
        void AddContact(Contact contact);
        void UpdateContact(int Id, Contact updateContact);        
        void DeleteContact(Contact contact);
    }
}
