using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeventLibrary.Models
{
    public class Address
    {
        private string _street, _city, _country, _zipcode;

        public Address()
        {
            _street = "testStreet";
            _city = "TestCity";
            _country = "TestCountry";
            _zipcode = "TestZipcode";
        }

        public Address(string street, string city, string country, string zipcode)
        {

        }

        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string Zipcode
        {
            get { return _zipcode; }
            set { _zipcode = value; }
        }
    }
}
