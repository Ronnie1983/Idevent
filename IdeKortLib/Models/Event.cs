using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeKortLib.Models
{
    public class Event
    {
        private int _id;
        private string _name;
        private int _location;
        private int _company;

        public Event()
        {
        }
        [Key]
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Location
        {
            get => _location;
            set => _location = value;
        }

        public int Company
        {
            get => _company;
            set => _company = value;
        }

        public Address LocationClass { get; set; }
        public User CompanyClass { get; set; }
    }
}
