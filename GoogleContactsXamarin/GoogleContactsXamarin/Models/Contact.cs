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
       
        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    firstName = value[0].ToString().ToUpper() + value.Substring(1);
                }
            }
        }

        private string lastName;
        public string LastName { 
            get 
            {
                return lastName;
            }
            set 
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    lastName = value[0].ToString().ToUpper() + value.Substring(1);
                }
            } 
        }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public string Company { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneLabel { get; set; }
        public string Email { get; set; }
        public string EmailLabel { get; set; }
        public string ColorHex { get; set; }
        public Contact()
        {
        }
    }
}
