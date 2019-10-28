
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactAPI.Models
{
    public class ContactModel
    {
        //public int Id { get; set; }
        public string Email { get; set; }
        public NameModel Name { get; set; }
        public AddressModel Address { get; set; }
        public PhoneModel Phone { get; set; }
    }
}