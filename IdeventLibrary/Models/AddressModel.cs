using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeventLibrary.Models
{
    [Table("Addresses")]
    public class AddressModel
    {
        private int _id;
        private string _streetAddress, _city, _country, _postalCode;

        public AddressModel()
        {
            
        }

        public AddressModel(string streetAddress, string city, string country, string postalCode)
        {
            StreetAddress = streetAddress;
            City = city;
            Country = country;
            PostalCode = postalCode;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        [MaxLength(100)]
        public string StreetAddress
        {
            get { return _streetAddress; }
            set { _streetAddress = value; }
        }
        [MaxLength(100)]
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        [MaxLength(100)]
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        [MaxLength(12)]
        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }
    }
}
