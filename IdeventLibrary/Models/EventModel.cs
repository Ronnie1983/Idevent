using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeventLibrary.Models
{
    public class EventModel
    {
        public EventModel(){}

        public EventModel(int id, string name, Company company, int amountOfConnectedChips)
        {
            Id = id;
            Name = name;
            Company = company;
            AmountOfConnectedChips = amountOfConnectedChips;
        }

        public int Id { get; init; }
        public string Name { get; set; }
        public Company Company { get; set; }
        public int AmountOfConnectedChips { get; set; } // data comes from a count on the Chips table.
    }
}
