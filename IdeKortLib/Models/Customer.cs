using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeKortLib.Models
{
    public class Customer
    {
        private int _id;
        private string _firstname;
        private string _lastname;

        public Customer()
        {
        }
        [Key]
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Firstname
        {
            get => _firstname;
            set => _firstname = value;
        }

        public string Lastname
        {
            get => _lastname;
            set => _lastname = value;
        }

    }
}
