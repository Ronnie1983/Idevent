using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeKortLib.Models
{
    public class Address
    {
        private int _id;
        private string _streetName;
        private string _number;
        private string _postalCode;
        private string _city;
        private string _country;

        public Address()
        {
        }

        public Address(string streetName, string number, string postalCode, string city, string country)
        {
            _streetName = streetName;
            _number = number;
            _postalCode = postalCode;
            _city = city;
            _country = country;
        }
        [Key]
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string StreetName
        {
            get => _streetName;
            set => _streetName = value;
        }

        public string Number
        {
            get => _number;
            set => _number = value;
        }

        public string PostalCode
        {
            get => _postalCode;
            set => _postalCode = value;
        }

        public string City
        {
            get => _city;
            set => _city = value;
        }

        public string Country
        {
            get => _country;
            set => _country = value;
        }
    }
}
