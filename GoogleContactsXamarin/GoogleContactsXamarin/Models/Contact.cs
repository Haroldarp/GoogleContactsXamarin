using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleContactsXamarin.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public string Company { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneLabel { get; set; }
        public string Email { get; set; }
        public string EmailLabel { get; set; }
        public Contact()
        {
        }
    }
}
