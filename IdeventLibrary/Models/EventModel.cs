﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeventLibrary.Models
{
    public class EventModel
    {
        public EventModel(){}

        public EventModel(string name, CompanyModel company) 
        { 
            Name = name;
            Company = company;
        }

        public EventModel(string name, CompanyModel company, int amountOfConnectedChips)
        {
            Name = name;
            Company = company;
            AmountOfConnectedChips = amountOfConnectedChips;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public CompanyModel Company { get; set; }
        public int AmountOfConnectedChips { get; set; } // data comes from a count on the Chips table.
        public List<EventStandModel> EventStands { get; set; }
    }
}
