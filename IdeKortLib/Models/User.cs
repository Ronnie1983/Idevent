using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeKortLib.Models
{
    public class User
    {
        private int _id;
        private string _email;
        private string _password;
        private int _active;
        private int _role;
        private int _address;
        private int _company;
        private int _customer;

        public User()
        {
            Role = 1;
        }
        [Key]
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public int Active
        {
            get => _active;
            set => _active = value;
        }

        public int Role
        {
            get => _role;
            set => _role = value;
        }

        public int Address
        {
            get => _address;
            set => _address = value;
        }

        public int Company
        {
            get => _company;
            set => _company = value;
        }

        public int Customer
        {
            get => _customer;
            set => _customer = value;
        }

        public Address AddressClass { get; set; } = null;

        public Role RoleClass { get; set; } = null;
        public Active ActiveClass { get; set; } = null;
        public Company CompanyClass { get; set; } = null;

        public Customer CustomerClass { get; set; } = null;

    }
}
