using System.Data.Entity;
using ContactAPI.Models;

namespace ContactAPI.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection") { }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Name> Name { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Phone> Phone { get; set; }
    }
       
}