using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeKortLib.Models
{
    public class Chip
    {
        private int _id;
        private int _company;
        private int _active;
        private int _event;
        private int _user;

        public Chip()
        {
        }

        public Chip(int id, int company, int active, int @event, int user, User companyClass, Active activeClass, Event eventClass, User userClass)
        {
            _id = id;
            _company = company;
            _active = active;
            _event = @event;
            _user = user;
            CompanyClass = companyClass;
            ActiveClass = activeClass;
            EventClass = eventClass;
            UserClass = userClass;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public int Company
        {
            get => _company;
            set => _company = value;
        }

        public int Active
        {
            get => _active;
            set => _active = value;
        }

        public int Event
        {
            get => _event;
            set => _event = value;
        }

        public int User
        {
            get => _user;
            set => _user = value;
        }

        public User CompanyClass { get; set; } = new User();
        public Active ActiveClass { get; set; } = new Active();
        public Event EventClass { get; set; } = new Event();
        public User UserClass { get; set; } = new User();

        public override string ToString()
        {
            return $"Key: {Id}, Company: {CompanyClass.CompanyClass.CompanyName}";
        }
    }
}
