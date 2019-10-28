using System.Collections.Generic;  
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactAPI.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string Email { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public Phone Phone { get; set; }

    }
        
    public class Name
    {
        [Key]
        public int NameId { get; set; }
        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }
        //Adding Foreign Key Constraints for Contacts
        //[ForeignKey("Contacts")]
        public int ContactId { get; set; }
    }

    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public int Zip { get; set; }
        //Adding Foreign Key Constraints for Contacts  
        //[ForeignKey("Contacts")]
        public int ContactId { get; set; }
    }

    public class Phone
    {
        [Key]
        public int PhoneId { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        //Adding Foreign Key Constraints for Contacts
        //[ForeignKey("Contacts")]
        public int ContactId { get; set; }

    }    
}