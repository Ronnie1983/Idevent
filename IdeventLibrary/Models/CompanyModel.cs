using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IdeventLibrary.Models
{
    public class CompanyModel
    {
        private int _id;
        private string _name, _email, _cvr, _phone;
        private AddressModel _address;
        private AddressModel _invoiceAddress;
        private bool _active;
        private string _note;

        
        public CompanyModel()
        {
            _id = 0;
            _name = "TestCompany";
            _email = "TestEmail";
            _address = new AddressModel();
        }
        public CompanyModel(string name, string email, string cvr, string phone, string street, string city, string postal, string country)
        {
            Name = name;
            Email = email;
            CVR = cvr;
            Phone = phone;
            Address = new AddressModel(street, city, country, postal);
    
        }

        private int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [Required]
        [MinLength(3)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Required]
        [EmailAddress]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public AddressModel InvoiceAddress
        {
            get { return _invoiceAddress; }
            set { _invoiceAddress = value; }
        }

        [Required]
        public AddressModel Address
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
        
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }
       
    }
}
