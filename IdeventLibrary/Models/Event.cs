using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeventLibrary.Models
{
    public class Event
    {
        private int _id;
        private string _name;
        private Company _company;

        public Event()
        {

        }

        public Event(string name, Company company)
        {
            _name = name;
            _company = company;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Company Company
        {
            get { return _company; }
            set { _company = value; }
        }
    }
}
