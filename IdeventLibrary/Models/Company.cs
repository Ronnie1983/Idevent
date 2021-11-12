using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IdeventLibrary.Models
{
    public class Company
    {
        private string _name, _email, _cvr, _phone;
        private Address _address;
        private Address _invoiceAddress;

        
        public Company()
        {
            
        }
        public Company(string name, string email, string cvr, string phone, string street, string city, string postal, string country)
        {
            Name = name;
            Email = email;
            CVR = cvr;
            Phone = phone;
            Address = new Address(street, city, country, postal);
    
        }

        [Required]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        [Required]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public Address InvoiceAddress
        {
            get { return _invoiceAddress; }
            set { _invoiceAddress = value; }
        }
        [Required]
        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }
        [Required]
        public string CVR
        {
            get { return _cvr; }
            set { _cvr = value; }
        }
        [Required]
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        
       
    }
}
