using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeventLibrary.Models
{
    [Table("Companies")]
    public class CompanyModel
    {
        private int _id;
        private string _name, _email, _cvr, _phone, _logo;
        private AddressModel _address;
        private AddressModel _invoiceAddress;
        private bool _active;
        private string _note;


        public CompanyModel()
        {
            _address = new AddressModel();
            _invoiceAddress = new AddressModel();
            _logo = "no url";
            _note = "no note";
        }
        public CompanyModel(int id, string name)
        {
            Id = id;
            Name = name;
            _address = new AddressModel();
            _invoiceAddress = new AddressModel();
            _logo = "no url";
            _note = "no note";
        }
        public CompanyModel(string name, string email, string cvr, string phone, string street, string city, string postal, string country, string streetInvoice, string cityInvoice, string postalInvoice, string countryInvoice)
        {
            Name = name;
            Email = email;
            CVR = cvr;
            PhoneNumber = phone;
            Address = new AddressModel(street, city, country, postal);
            Address = new AddressModel(streetInvoice, cityInvoice, countryInvoice, postalInvoice);

        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public AddressModel? InvoiceAddress
        {
            get { return _invoiceAddress; }
            set { _invoiceAddress = value; }
        }

        [Required]
        public AddressModel? Address
        {
            get { return _address; }
            set { _address = value; }
        }

        [Required]
        [MaxLength(8)]
        public string CVR
        {
            get { return _cvr; }
            set { _cvr = value; }
        }

        [Required]
        [MaxLength(30)]
        public string PhoneNumber
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
        public string Logo
        {
            get { return _logo; }
            set { _logo = value; }
        }

    }
}
